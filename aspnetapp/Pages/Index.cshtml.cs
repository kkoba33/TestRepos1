using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace aspnetapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _webHostEnvironment;

    public IList<ClassDat> lstClassDat;

    private const string constFileName = "sample_data.dat";

    public IndexModel(ILogger<IndexModel> logger, Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnvironment)
    {
        this._webHostEnvironment = webHostEnvironment;
        this._logger = logger;

        this.lstClassDat = new List<ClassDat>();
    }

    //public IndexModel(ILogger<IndexModel> logger)
    //{
    //    _logger = logger;
    //}

    public void OnGet()
    {
        //-----------------------------------------------------------------    
        string _path = System.IO.Path.Combine(_webHostEnvironment.ContentRootPath, constFileName);
        var _contens = System.IO.File.ReadAllText(_path).Split('\n');
        var _csv = from c in _contens
                   select c.Split(',').ToArray();
        //-----------------------------------------------------------------
        var _item = new ClassDat();

        _item.WebRootPath = this._webHostEnvironment.WebRootPath;
        _item.ContentRootPath = this._webHostEnvironment.ContentRootPath;
        _item.DataPath = _path;
        _item.DataRows = _csv.Count();

        this.lstClassDat.Add(_item);
        //-----------------------------------------------------------------
        Debug.WriteLine(_item.WebRootPath);
        Debug.WriteLine(_item.ContentRootPath);
        //-----------------------------------------------------------------
    }


}
