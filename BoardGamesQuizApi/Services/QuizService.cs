using System.Text.Json;
using Microsoft.Extensions.Hosting;

namespace BoardGamesQuizApi.Services;

public class QuizService
{
    private readonly Dictionary<int, JsonElement> _quizzes;
    private readonly Dictionary<int, JsonElement> _results;

    public QuizService(IHostEnvironment env)
    {
        string dataDir = Path.Combine(env.ContentRootPath, "Data");
        _quizzes = new()
        {
            [12] = JsonDocument.Parse(File.ReadAllText(Path.Combine(dataDir, "quiz.json"))).RootElement
        };
        _results = new()
        {
            [12] = JsonDocument.Parse(File.ReadAllText(Path.Combine(dataDir, "result.json"))).RootElement
        };
    }

    public JsonElement? GetQuiz(int id) => _quizzes.TryGetValue(id, out var q) ? q : null;
    public JsonElement? GetResult(int id) => _results.TryGetValue(id, out var r) ? r : null;
}
