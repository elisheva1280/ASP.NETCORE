using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyModelsLib.Interface;
namespace lesson2.Controllers;

public class WorkerController : BaseCcntroller
{

    IWorkerService _w;
    public WorkerController(IWorkerService w)
    {
        _w = w;
    }

    [Authorize(Policy ="Admin")]
    [Route("[action]/{id}")]
    [HttpGet]
    public IActionResult WGetById(int id)
    {
        var Worker = _w.SWGetById(id);
        if (Worker == null)
        {
            return NotFound();
        }
        return Ok();
    }


    [Route("[action]/{nameOfWorker}")]
    [HttpGet]
    public IActionResult WGetByName(string name)
    {
        var Worker = _w.SWGetByName(name);
        if (Worker == null)
        {
            return NotFound();
        }
        return Ok();
    }

    [Authorize(Policy ="Admin")]
    [Route("[action]")]
    [HttpPost]
    public IActionResult WPost(string nameOfWorker, int id, int hourS, string pass, string role)
    {
        //SWPost(nameOfWorker, id, hourS, pass, role);
        var add = _w.SWPost(nameOfWorker, id, hourS,pass,role);
        if (add)
            return Ok();
        return NotFound();
    }


    [Route("[action]/{id}/{name}")]
    [HttpPut]
    public IActionResult WputName(int id, string name)
    {
        var d = _w.SWputName(id, name);
        if (d)
            return Ok();
        return NotFound();

    }

    [Route("[action]/{id}/{glotan}")]
    [HttpPut]
    public void WputHours(int id, int hours)
    {
        _w.SWputHours(id, hours);

    }

    [Route("[action]/{id}")]
    [HttpDelete]
    public void Del(int id)
    {
        _w.SWDel(id);
    }
}

