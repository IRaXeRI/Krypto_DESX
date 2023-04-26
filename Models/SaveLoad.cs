using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;

public class SaveLoad
{
	public string load(string readPath) {
		return File.ReadAllText(readPath, Encoding.UTF8);
	}

	public void save(string codePath, string msg) {
		using (FileStream fileCreateStream = File.Create(codePath)) {
		}
		string writingLine = msg;
		using (StreamWriter write = new StreamWriter(codePath)) {
		}
		File.AppendAllText(codePath, new string(writingLine.ToArray()), Encoding.UTF8);
	}
}