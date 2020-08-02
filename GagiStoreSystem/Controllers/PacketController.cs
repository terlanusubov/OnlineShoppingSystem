using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GagiStoreSystem.Data;
using GagiStoreSystem.Enums;
using GagiStoreSystem.Infrastructure.Models;
using GagiStoreSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderStatus = GagiStoreSystem.Enums.OrderStatus;

namespace GagiStoreSystem.Controllers
{
    public class PacketController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PacketController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> List()
        {
            var packets = await _context.Packets.OrderByDescending(c=>c.Id).ToListAsync();
            return View(packets);
        }

        public IActionResult Add()
        {
            return View(new PacketM());
        }
        [HttpPost]
        public async Task<IActionResult> Add(PacketM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var packet = await _context.Packets.Where(c => c.TrackingNumber == model.TrackingNumber).FirstOrDefaultAsync();
            if(packet != null)
            {
                ModelState.AddModelError("", "Belə bir bağlama artıq mövcuddur.");
                return View(model);
            }

            packet = new Packet
            {
                PacketStatusId = (int)Enums.PacketStatus.OnHold,
                Link = model.TrackingLink,
                ProductCount = 0,
                Orders = new List<Order>(),
                TrackingNumber = model.TrackingNumber
            };

            await _context.Packets.AddAsync(packet);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Packet");
        }

        public async Task<IActionResult> Edit(int? packetId)
        {
            if (packetId == null)
                return RedirectToAction("List", "Packet");

            var packet = await _context.Packets.Where(c => c.Id == packetId).FirstOrDefaultAsync();
            if (packet == null)
                return RedirectToAction("List", "Packet");

            ViewBag.PacketId = packetId;
            return View(packet);
        }

        public IActionResult AddOrder(int? packetId)
        {
            ViewBag.PacketId = packetId;
            return View(new OrderM());
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Order order = new Order
            {
                OrderStatusId = Convert.ToInt32(Enums.OrderStatus.Waiting),
                ReceiverSurname = model.ReceiverSurname,
                ReceiverName = model.ReceiverName,
                Instagram = model.Instagram,
                PacketId = model.PacketId,
                OrderDate = model.OrderDate,
                Note = model.Note,
                Phone = model.Phone,
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("OrderDetail", "Packet", new { orderId = order.Id});
        }


        public async Task<IActionResult> OrderDetail(int? orderId)
        {
            if (orderId == null)
                return RedirectToAction("List", "Packet");

            var order = await _context.Orders.Where(c => c.Id == orderId).FirstOrDefaultAsync();
            if (order == null)
                return RedirectToAction("List", "Packet");

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order model)
        {
            if(model.ReceiverName !=null &&
               model.ReceiverSurname !=null &&
               model.Phone != null &&
               model.Instagram !=null &&
               model.OrderDate != null &&
               model.Note != null)
            {
                var order = await _context.Orders.Where(c => c.Id == model.Id && c.OrderStatusId != Convert.ToInt32(OrderStatus.HandedOver)).FirstOrDefaultAsync();
                if(order == null)
                    return RedirectToAction("OrderDetail", "Packet", new { orderId = model.Id });


                order.ReceiverName = model.ReceiverName;
                order.ReceiverSurname = model.ReceiverSurname;
                order.Note = model.Note;
                order.Phone = model.Phone;
                order.Instagram = model.Instagram;
                order.OrderDate = model.OrderDate;

                await _context.SaveChangesAsync();
                return RedirectToAction("OrderDetail", "Packet", new { orderId = model.Id });
            }


            return RedirectToAction("OrderDetail","Packet",new { orderId = model.Id});
        }

        [HttpPost]
        public async Task<JsonResult> AddOrderDetail(int? orderId,OrderDetailAddM model)
        {
            if (orderId == null || !ModelState.IsValid)
                return Json(new
                {
                    status = 400
                });

            var order = await _context.Orders.Where(c => c.Id == orderId).FirstOrDefaultAsync();
            if (order == null)
                return Json(new
                {
                    status = 400
                });

            var product = await _context.Products.Where(c => c.Id == model.ProductId).FirstOrDefaultAsync();
            var orderDetail = new OrderDetails
            {
                OrderId = order.Id,
                ProductId = model.ProductId,
                TotalDiscount = model.Discount,
                Count = (int)model.Count,
                OrderDetailStatusId = Convert.ToInt32(OrderDetailStatus.Waiting),
                Note = model.Note,
                TotalAmount = (model.Count*product.SaleAmount)-model.Discount,
            };

             order.OrderDetails.Add(orderDetail);
            order.TotalAmount = order.OrderDetails.Sum(c => c.TotalAmount);
            order.TotalDiscount = order.OrderDetails.Sum(c => c.TotalDiscount);

            await _context.SaveChangesAsync();
            return Json(new
            {
                status = 200
            });
        }
        [HttpPost]
        public async Task<JsonResult> UpdateStatusOfOrderDetail(int? orderDetailId,int? status)
        {
            if (orderDetailId == null || status == null)
                return Json(new { status = 400 });

            var orderDetail = await _context.OrderDetails.Where(c => c.Id == orderDetailId && c.OrderDetailStatusId == Convert.ToInt32(OrderDetailStatus.Waiting)).FirstOrDefaultAsync();
            if (orderDetail == null)
                return Json(new { status = 400 });

            orderDetail.OrderDetailStatusId = (int)status;
            await _context.SaveChangesAsync();
            return Json(new { status = 200 });
        }
    }
}
