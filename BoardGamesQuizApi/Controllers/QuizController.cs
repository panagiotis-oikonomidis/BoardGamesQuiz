using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BoardGamesQuizApi.Services;

namespace BoardGamesQuizApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizzesController : ControllerBase
{
    private readonly QuizService _service;
    public QuizzesController(QuizService repo) => _service = repo;

    [HttpGet("{id:int}")]
    public IActionResult GetQuiz(int id)
        => _service.GetQuiz(id) is { } q ? Ok(q) : NotFound();

    [HttpGet("{id:int}/results")]
    public IActionResult GetResults(int id)
        => _service.GetResult(id) is { } r ? Ok(r) : NotFound();
}
