using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;

public class SaveLoad
{
	public byte[] load(string readPath) {
		return File.ReadAllBytes(readPath);
	}

	public void save(string codePath, byte[] msg) {
		using (FileStream fileCreateStream = File.Create(codePath)) {
		}
		using (StreamWriter write = new StreamWriter(codePath)) {
		}
		File.WriteAllBytes(codePath, msg);
	}
}