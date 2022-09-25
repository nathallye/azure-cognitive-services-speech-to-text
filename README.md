- **Reconhecimento de Síntese de Fala**
  -  Use os recursos de conversão de fala em texto do serviço de Fala para transformar fala audível em texto - áudio para texto
  -  Use os recursos de conversão de texto em fala do serviço de Fala para gerar fala audivel a partir de um texto - texto para áudio
   
  ![image](https://user-images.githubusercontent.com/86172286/192125334-26376332-828c-48dc-b39a-fc09964d55c6.png)
  
- **No Visual Studio**

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

  4. Criação da subscription ID
    No `Portal do Azure` vamos em `Criar um recurso(Create a resource)` em seguida buscaremos por `Cognitive Services` em seguida podemos criar clicando em `Create`