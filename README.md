# Aplicativo de Reconhecimento e Síntese de Fala usando os Serviços Cognitivos da Microsoft

## Reconhecimento e Síntese de Fala
  1. Uso dos recursos de conversão de fala em texto do serviço de Fala para transformar fala audível em texto - áudio para texto;
  2. Uso dos recursos de conversão de texto em fala do serviço de Fala para gerar fala audivel a partir de um texto - texto para áudio.
  
- **Processamento de Linguagem Natural**
  - Serviços Cognitivos do Microsoft Azure
    - Speech

## Criação do projeto - no Visual Studio

  1. O primeiro passo foi iniciar um projeto simples de console:
  
  ``` C#
  using System;

  namespace Mic
  {
    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");
      }
    }
  }
  ```

  2. Feito isso, precisamos instalar o pacote `Microsoft.CognitiveServices.Speech`, podemos fazer isso usando o comando a seguir:

  ```
  Install-Package Microsoft.CognitiveServices.Speech
  ```

  Ou, seguindo os passos seguintes: `Projeto` > `Gerenciar pacotes do NuGet...` > `Procurar` > `Microsoft.CognitiveServices.Speech` > `Instalar`.

  3. Concluído a instalação do pacote conseguimos usá-lo no projeto:

  ``` C#
  using System;
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;

  namespace Mic
  {
    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");
      }
    }
  }
  ```

  4. **Criação da subscription ID:** No `Portal do Azure` vamos em `Criar um recurso(Create a resource)` em seguida buscaremos por `Cognitive Services` em seguida podemos criar clicando em `Create`.
    
  - Concluído os passos acima iremos para a tela de `Create Cognitive Services` na seção `Basics` e preencheremos os campos da forma seguinte:

    ![image](https://user-images.githubusercontent.com/86172286/192127942-a3cee6d1-ec98-4503-9767-be173c2efec3.png)

  - Em seguida, na seção `Identity` preencheremos os campos da forma seguinte:

    ![image](https://user-images.githubusercontent.com/86172286/192128011-4791f51b-2857-475f-92df-6f91c51812a9.png)

  - Na seção `Tags` preencheremos os campos da forma seguinte:

    ![image](https://user-images.githubusercontent.com/86172286/192128035-54e95c48-f021-43f6-b659-4881621bee07.png)

  - Por fim, em `Review + Create` podemos revisão as informações e criar esse recurso clicando em `Create`.

  - Depois que o recurso for provisionado aparecerá a mensagem `Your deployment is complete` e podemos acessar esse recurso clicando em `Go to resource`.

    ![image](https://user-images.githubusercontent.com/86172286/192128144-255a4e2c-dbf8-4139-b8a2-9b721b7ba959.png)

  - Agora em `Keys and Endpoint(Chaves e Ponto de Extremidade)`, conseguimos encontrar a chave da assinatura para inserirmos no código no Visual Studio  

    ![image](https://user-images.githubusercontent.com/86172286/192128224-1c156b3d-ae11-4c15-b23c-e83e56904998.png)

    ``` C#
    using System;
    using Microsoft.CognitiveServices.Speech;
    using Microsoft.CognitiveServices.Speech.Audio;

    namespace Mic
    {
      class Program
      {
        static void Main(string[] args)
        {
          Console.WriteLine("Hello, girl!");
          var config = SpeechConfig.FromSubscription("subscription_KEY 1", "subscription_Location/Region");
        }
      }
    }
    ```
    
  5. Capturando o áudio do microfone padrão configurado na máquina:

  ``` C#
  using System;
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;

  namespace Mic
  {
    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");
        var config = SpeechConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        var audioConfig = AudioConfig.FromDefaultMicrophoneInput(); // esse áudio pode ter outras origens ao invés do microfone, por exemplo de um file
      }
    }
  }
  ```

  6. Após capturarmos o áudio precisamos reconhecer/`recognizer` esse áudio. Para isso, vamos criar uma nova instância de `SpeeachRecognizer` passando o `config`(que contém as informações do id subscription), o idiona que queremos reconher nesse áudio que no caso é `pt-br` e o audio capturado `audioConfig`:

  ``` C#
  using System;
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;

  namespace Mic
  {
    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");
        var config = SpeechConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
        var recognizer = new SpeechRecognizer(config, "pt-br", audioConfig);
      }
    }
  }
  ```

  7. Para ficar claro que falamos no microfone vamos exibir um console depois que o áudio for capturado:

  ``` C#
  using System;
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;

  namespace Mic
  {
    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");
        var config = SpeechConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth"); 
        var audioConfig = AudioConfig.FromDefaultMicrophoneInput(); 
        var recognizer = new SpeechRecognizer(config, "pt-br", audioConfig);
        Console.WriteLine("Pronto falei!");
      }
    }
  }
  ```  

  8. E para capturarmos esse resultado de forma assíncrona primeiramente vamos mudar o método de `static void Main` para `static assyn Task Main` em seguida vamos armazenar dentro da variável `result` a retornada do `recognizer`:

  ``` C#
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
        var audioConfig = AudioConfig.FromDefaultMicrophoneInput(); 
        var recognizer = new SpeechRecognizer(config, "pt-br", audioConfig);
        Console.WriteLine("Pronto falei!");

        var result = await recognizer.RecognizeOnceAsync(); // await é utilizado para esperar por uma Promise. 
      }
    }
  }
  ```

  E de dentro dessa promise armazenada em `result` vamos pegar o valor texto e armazená-lo em na variável `text`:

  ``` C#
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
        var audioConfig = AudioConfig.FromDefaultMicrophoneInput(); 
        var recognizer = new SpeechRecognizer(config, "pt-br", audioConfig);
        Console.WriteLine("Pronto falei!");

        var result = await recognizer.RecognizeOnceAsync(); // await é utilizado para esperar por uma Promise. 
        var text = result.Text;
      }
    }
  }
  ```
  
  9. Agora podemos escrever na tela o texto reconhecido:

  ``` C#
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
        var audioConfig = AudioConfig.FromDefaultMicrophoneInput(); 
        var recognizer = new SpeechRecognizer(config, "pt-br", audioConfig);
        Console.WriteLine("Pronto falei!");

        var result = await recognizer.RecognizeOnceAsync();  
        var text = result.Text;

        Console.WriteLine($"Reconhecido: {text}");
      }
    }
  }
  ```

  10. E para ele depois que exibir o console continue esperando "na linha" ao invés de encerrar a aplicação vamos usar o `ReadKey`:

  ``` C#
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
        var audioConfig = AudioConfig.FromDefaultMicrophoneInput(); 
        var recognizer = new SpeechRecognizer(config, "pt-br", audioConfig);
        Console.WriteLine("Pronto falei!");

        var result = await recognizer.RecognizeOnceAsync(); 
        var text = result.Text;

        Console.WriteLine($"Reconhecido: {text}");

        Console.ReadKey(); // método para aguardar que o usuário pressione a tecla Enter antes de encerrar o aplicativo
      }
    }
  }
  ```
    
  11. Agora, conseguimos executar nossa aplicação e testar:
    
   ![image](https://user-images.githubusercontent.com/86172286/192172037-cb4cf978-8eae-4157-bfd6-26288a771b7b.png)

    
  12. Pronto, a aplicação já está reconhecendo o áudio da fonte configurada e escrevendo no console o que foi dito. Para melhorar, vamos usar um `while` para que ele continue escutando até que seja escrito no terminal a palavra `sair`:

  ``` C#
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
  ```
