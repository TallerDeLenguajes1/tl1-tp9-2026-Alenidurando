using System.ComponentModel;
using System.IO;
string? path;


do
{
    Console.Write("Ingrese un directorio: ");
    path = Console.ReadLine();

    if (!Directory.Exists(path))
    {
        Console.WriteLine("El directorio no existe.");
    }

} while (!Directory.Exists(path));

System.Console.WriteLine("\nCarpetas: ");

string[]? carpetas =Directory.GetDirectories(path);


foreach(string archivo in carpetas)
{
    Console.WriteLine(
        Path.GetFileName(archivo)
    );
}

Console.WriteLine("\nArchivos:");

string[] archivos = Directory.GetFiles(path);

StreamWriter guardar = new StreamWriter( Path.Combine(path,"reporte_archivos.csv"));

foreach (string archivo in archivos)
{
    FileInfo info = new FileInfo(archivo);

    double tamanioKB = info.Length / 1024.0;

    Console.WriteLine(
        $"{info.Name} - {tamanioKB:F2} KB"
    );

    string linea=$"{info.Name}-{tamanioKB:F2}KB-{info.LastWriteTime}";
    guardar.WriteLine(linea);

}

guardar.Close();

