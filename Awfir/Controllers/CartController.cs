using BusinessLogic.Interface;
using BusinessLogic.Models;
using BusinessLogic.Repository;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Awfir.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CartController : ApiController
    {
        public ICart _cart;
        public CartController()
        {
            _cart = new CartRepository(new AwfirContext());
        }
        [HttpGet]
        public IHttpActionResult GetCartItemList(Guid id)
        {
            try
            {
                if (id != null)
                {
                    var data = _cart.GetCartDealList(id);
                    if (data != null)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult AddCartItem(Cart item)
        {
            try
            {
                if (item != null)
                {
                    var data = _cart.InsertDeal(item);
                    if (data == true)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateCartItem(UpdateCartModel deal)
        {
            try
            {
                if (deal != null)
                {
                    var record = _cart.CartPlusMinus(deal);
                    if (record == true)
                    {
                        return Ok(record);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public IHttpActionResult DeleteCartItem(Guid id)
        {
            try
            {
                if (id != null)
                {
                    var data = _cart.DeleteDealByID(id);
                    if (data == true)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
