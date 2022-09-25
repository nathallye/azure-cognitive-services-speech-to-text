using System;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Mic
{
  class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("Hello, girl!");
      var config = SpeechConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth"); 
      var audioConfig = AudioConfig.FromDefaultMicrophoneInput(); // esse áudio pode ter outras origens ao invés do microfone, por exemplo de um file
      var recognizer = new SpeechRecognizer(config, "pt-br", audioConfig);
      Console.WriteLine("Parei de falar!");

      while(true)
      {
        var result = await recognizer.RecognizeOnceAsync(); // await é utilizado para esperar por uma Promise. 
        var text = result.Text;

        Console.WriteLine($"Reconhecido: {text}");
        if (text.ToLower().Contains("sair"))
        {
          break;
        }
      }
      Console.ReadKey(); // método para aguardar que o usuário pressione a tecla Enter antes de encerrar o aplicativo
    }
  }
}