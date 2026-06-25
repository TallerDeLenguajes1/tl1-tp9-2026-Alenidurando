using tag;
using System.IO;
using System.Text;
string path="prueba.mp3";

Id3v1Tag audio = new Id3v1Tag();
FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read);

fs.Seek(-128, SeekOrigin.End); //leer desde 128bytes antes del final del archivo.

BinaryReader lector = new BinaryReader(fs);

byte[] datos = lector.ReadBytes(128);

audio.Titulo = Encoding.GetEncoding("latin1").GetString(datos, 3, 30).TrimEnd('\0', ' ');
audio.Album= Encoding.GetEncoding("latin1").GetString(datos, 63, 30).TrimEnd('\0', ' ');
audio.Anio= Encoding.GetEncoding("latin1").GetString(datos, 93, 30).TrimEnd('\0', ' ');
audio.Artista= Encoding.GetEncoding("latin1").GetString(datos, 33, 30).TrimEnd('\0', ' ');


System.Console.WriteLine("Datos del mp3: \nTitulo: "+audio.Titulo+"\nAño: "+audio.Anio+"\nArtista: "+audio.Artista+"\nAlbum: "+audio.Album);


