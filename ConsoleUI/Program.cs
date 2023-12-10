// See https://aka.ms/new-console-template for more information
using BusinessCore.Abstract;
using BusinessCore.Concrete;
using Data.Concrete;
using Data.Db;
using Data.Models;

Console.WriteLine("Hello, World!");

ThesesContext db = new ThesesContext();

var theses = db.Set<Thesis>().ToList();
foreach (var item in theses)
{
Console.WriteLine(item.INSTITUTEID);

}

Console.WriteLine(theses.Select(T => new { T.THESISID, T.INSTITUTEID, T.SUBMISSIONDATE, T.LANGUAGE, T.NUMBER }).ToList().AsReadOnly());
Console.ReadLine();