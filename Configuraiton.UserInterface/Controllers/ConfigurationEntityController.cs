using Configuration.Business.Abstract;
using Configuration.Data.Entities;
using Configuration.UserInterface.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Configuration.UserInterface.Controllers
{
    public class ConfigurationEntityController : Controller
    {
        private IConfigurationService _configurationService;

        public ConfigurationEntityController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public IActionResult Index()
        {
            var configurationList = _configurationService.TGetAll();
            return View(configurationList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateConfigurationEntityVM model)
        {
            _configurationService.TAddAsync(new ConfigurationEntity()
            {
                ApplicationName = model.ApplicationName,
                IsActive = model.IsActive,
                Name = model.Name,
                Type = model.Type,
                Value = model.Value
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var configuration = _configurationService.TGetById(id);
            var model = new UpdateConfigurationEntityVM()
            {
                Id = configuration.Id,
                ApplicationName = configuration.ApplicationName,
                IsActive = configuration.IsActive,
                Name = configuration.Name,
                Type = configuration.Type,
                Value = configuration.Value
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateConfigurationEntityVM model)
        {
            _configurationService.TUpdateAsync(new ConfigurationEntity()
            {
                Id = model.Id,
                ApplicationName = model.ApplicationName,
                IsActive = model.IsActive,
                Name = model.Name,
                Type = model.Type,
                Value = model.Value
            });
            return View(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var configurationEntity = _configurationService.TGetById(id);
            return Ok(configurationEntity);
        }

    }
}
