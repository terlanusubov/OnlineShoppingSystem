function AjaxCaller(url, type, data, success, error, needLoader = true) {
    var loader = new Loader("preloader.svg");
    if (needLoader) {
        loader.show($(document.body));
    }

    var dataToSend = ToFormData(data);
    $.ajax({
        url: url,
        type: type,
        dataType: "json",
        data: dataToSend,
        cache: false,
        processData: false,
        contentType:false,
        success: function (response) {
            if (response.status == 200) {
                success(response, loader);
            }
            else {
                error(response, loader);
            }
        }
    })
}
function Loader(_src) {
    this.src = _src;
    this.show = function (appendTo) {
        appendTo.append($(`<div class="overlay-preloader">
                        <img src="/${this.src}" />    
                        </div>`));
    };

    this.remove = function () {
        $(document.body).find(".overlay-preloader").remove();
    };
}
function ToFormData(obj, form, namespace) {
    let fd = form || new FormData();
    let formKey;

    for (let property in obj) {
        if (obj.hasOwnProperty(property) && obj[property]) {
            if (namespace && Array.isArray(obj)) {
                formKey = namespace + '[' + property + ']';
            }
            else if (namespace) {
                formKey = namespace + '.' + property;
            }
            else {
                formKey = property;
            }

            // if the property is an object, but not a File, use recursivity.
            if (obj[property] instanceof Date) {
                fd.append(formKey, obj[property].toISOString());
            }
            else if (typeof obj[property] === 'object' && !(obj[property] instanceof File)) {
                toFormData(obj[property], fd, formKey);
            } else { // if it's a string or a File object
                fd.append(formKey, obj[property]);
            }
        }
    }
    return fd;
}
