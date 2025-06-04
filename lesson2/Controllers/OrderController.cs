using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using MyModelsLib.Interface;
using MyModelsLib;
namespace lesson2.Controllers;

// using MyModelsLib;
// using MyModelsLib.Interface;
// using MyFileServiceLib.Interface;


public class OrderController : BaseCcntroller
{

IOrderService  _o;
public OrderController (IOrderService o)
{
    _o = o;
}

[Route("[action]/{id}")]
[HttpGet]
// public async Task<ActionResult> GetById(int id){
// await _M.SGetById(id);
// return Ok();
// }

public IActionResult OGetById(int id){
    var Order = _o.SOGetById(id);
    if (Order==null){
        return NotFound();
    }
     return Ok();
}

[Route("[action]/{id}/{nameOfCustumer}/{creditcard}")]
[HttpPost]
public IActionResult OPost(int id, string nameOfCustumer, string creditcardn,int cv,int ex){
    var add=_o.SOPost(id,nameOfCustumer,creditcardn,cv,ex);
    if (add){
        return Ok();
    }
     return NotFound();
}

}