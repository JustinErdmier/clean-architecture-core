using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

//TODO: Move to Shared folder or Common project?

namespace CleanArchitecture.Service;

public sealed class LowercaseDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        OpenApiPaths paths = swaggerDoc.Paths;

        var newPaths = new Dictionary<string, OpenApiPathItem>();

        var removeKeys = new List<string>();

        foreach (KeyValuePair<string, OpenApiPathItem> path in paths)
        {
            string newKey = path.Key.ToLower();

            if (newKey == path.Key)
                continue;

            removeKeys.Add(path.Key);

            newPaths.Add(newKey, path.Value);
        }

        foreach (KeyValuePair<string, OpenApiPathItem> path in newPaths)
        {
            swaggerDoc.Paths.Add(path.Key, path.Value);
        }

        foreach (string key in removeKeys)
        {
            swaggerDoc.Paths.Remove(key);
        }
    }
}
