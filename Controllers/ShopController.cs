using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.MediatR.Query;
using Store.Models.DTOs;
using Store.Models.Goods;

namespace Store.Controllers
{

    public class ShopController : Controller
    {
        private IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Goods()
        {

            var command = new GetGoodsQuery();
            var response = _mediator.Send(command);
            var query = new GetCategoriesQuery();
            var categories = await _mediator.Send(query);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(response.Result);


        }
        [HttpPost]
        public async Task<IActionResult> Goods([FromForm] string Id, string Min, string Max, string Sort)
        {
            var command = new GetGoodsWithParamsQuery(Id, Min, Max);
            var goods = await _mediator.Send(command);
            switch (Sort)
            {
                case "low":
                    goods = (from x in goods
                             orderby x.Price
                             select x).ToList();
                    break;
                case "high":
                    goods = (from x in goods
                             orderby x.Price descending
                             select x).ToList();
                    break;

            }

            var query = new GetCategoriesQuery();
            var categories = await _mediator.Send(query);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View("Goods", goods);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var query = new GetCategoriesQuery();
            var categories = await _mediator.Send(query);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            if (User.IsInRole("admin"))
            {
                return View();
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]

        public IActionResult Create([FromForm] GoodsModel Goods)
        {
            if (User.IsInRole("admin"))
            {
                var command = new CreateGoodsCommand(Goods);
                _mediator.Send(command);
                return RedirectToAction("Goods", "Shop");
            }
            return NotFound();

        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var query = new GetSingleGoodsQuery(Id);
            var result = await _mediator.Send(query);
            return View(result);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, [FromForm] GoodsModel Goods)
        {
            Goods.Id = Id;
            var command = new EditGoodsCommand(Goods);
            await _mediator.Send(command);
            return RedirectToAction("Goods", "Shop");
        }
        [HttpGet]
        public async Task<IActionResult> AddToCart(string Id)
        {
            var command = new AddToCartCommand(User.Identity.Name, Id);
            var result = await _mediator.Send(command);
            return RedirectToAction("Goods", "Shop");
        }
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var command = new GetUserCartQuery(User.Identity.Name);
            var result = await _mediator.Send(command);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteFromCart(string Id)
        {
            var command = new DeleteGoodsFromCartCommand(User.Identity.Name, Id);
            var result = await _mediator.Send(command);
            return RedirectToAction("Cart", "Shop");
        }
        [HttpPost]
        public async Task<IActionResult> MakeOrder([FromForm] string Address)
        {
            var command = new MakeOrderCommand(User.Identity.Name, Address);
            var result = await _mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var query = new GetCategoriesQuery();
            var categories = await _mediator.Send(query);
            return View(categories);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] string Name)
        {
            var command = new CreateNewCategoryCommand(Name);
            var result = await _mediator.Send(command);
            return RedirectToAction("Categories", "Shop");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(string Id)
        {
            var command = new DeleteCategoryCommand(Id);
            await _mediator.Send(command);

            return RedirectToAction("Categories", "Shop");
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetails(Guid Id)
        {
            var query = new GetOrderDetailsQuery(Id);
            var orderDetails = await _mediator.Send(query);


            return View(orderDetails);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteGoods(Guid Id)
        {
            var command = new DeleteGoodsCommand(Id);
            var result = await _mediator.Send(command);
            return RedirectToAction("Goods", "Shop");
        }
        [HttpGet]
        public async Task<IActionResult> Product(Guid Id)
        {
            var command = new GetSingleGoodsQuery(Id);
            var goods = await _mediator.Send(command);
            var command2 = new GetCommentsQuery(Id);
            var comments = await _mediator.Send(command2);
            ProductModel product = new ProductModel { Comments = comments, Goods = goods };
            return View(product);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteComment(Guid Id)
        {
            var command = new DeleteCommentCommand(Id);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateComment([FromForm] string Id, string Text)
        {
            var command = new CreateCommentCommand(User.Identity.Name, Guid.Parse(Id), Text);
            _mediator.Send(command);
            return Redirect($"/Shop/Product/{Id}");
        }
        
    }
}
