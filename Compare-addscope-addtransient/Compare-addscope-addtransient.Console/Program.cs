

using System.Text;
using Compare_addscope_addtransient.Console;
using Microsoft.Extensions.DependencyInjection;

var collection=new ServiceCollection();

collection.AddScoped<ScopedClass>();
collection.AddTransient<TransientClass>();


var builder=collection.BuildServiceProvider();
Console.Clear();
StringBuilder scopedString=new StringBuilder();
StringBuilder transientString = new StringBuilder();

for (int i = 0; i < 10; i++)
{
    scopedString.AppendLine($"Scoped ID ={builder.GetService<ScopedClass>()?.GetHashCode().ToString()}");
    transientString.AppendLine($"Transient ID ={builder.GetService<TransientClass>()?.GetHashCode().ToString()}");

}

Console.WriteLine(scopedString);
Console.WriteLine(transientString);