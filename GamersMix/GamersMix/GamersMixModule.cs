using System.Linq;
using Nancy;
using Newtonsoft.Json;

namespace GamersMix
{
    public sealed class GamersMixModule : NancyModule
    {
        public GamersMixModule() : base("/api")
        {
            Get["/ping"] = parameters => Response.AsJson("pong");

            Get["/soundControllers/get"] = parameters =>
            {
                var apps = SoundLib.EnumerateApplications().Distinct().ToList();
                var json = JsonConvert.SerializeObject(apps);

                return json;
            };

            Get["/soundControllers/get/{name}"] = parameters =>
            {
                var appName = parameters["name"];
                var app = SoundLib.EnumerateApplications().FirstOrDefault(a => a == appName);

                if (app == null)
                {
                    return string.Empty;
                }

                var volume = SoundLib.GetApplicationVolume(app);
                return volume.ToString();
            };

            Get["/soundControllers/set/{name}/{volume}"] = parameters =>
            {
                var appName = parameters["name"];
                var app = SoundLib.EnumerateApplications().FirstOrDefault(a => a == appName);

                if (app == null)
                {
                    return string.Empty;
                }

                float volume;
                var volumeOk = float.TryParse(parameters["volume"], out volume);

                if (volumeOk)
                {
                    SoundLib.SetApplicationVolume(appName, volume);
                }

                return string.Empty;
            };
        }
    }
}
