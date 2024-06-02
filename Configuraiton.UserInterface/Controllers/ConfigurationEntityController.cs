using AutoMapper;
using Configuration.Business.Abstract;
using Configuration.Data.Entities;
using Configuration.UserInterface.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Configuration.UserInterface.Controllers
{
    public class ConfigurationEntityController : Controller
    {
        private IConfigurationService _configurationService;
        private IMapper _mapper;

        public ConfigurationEntityController(IConfigurationService configurationService, IMapper mapper)
        {
            _configurationService = configurationService;
            _mapper = mapper;
        }

        public IActionResult Index(string searchTerm = null)
        {
            var configurationList = string.IsNullOrEmpty(searchTerm)
                ? _configurationService.TGetAll().ToList()
                : _configurationService.TSearch(searchTerm).ToList();

            ViewData["searchTerm"] = searchTerm;
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
            var configurationEntity = _mapper.Map<ConfigurationEntity>(model);
            _configurationService.TUpdateAsync(configurationEntity);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var configurationEntity = _configurationService.TGetById(id);
            return Ok(configurationEntity);
        }

    }
}
