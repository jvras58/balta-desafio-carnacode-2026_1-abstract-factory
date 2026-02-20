# Como rodar a aplicação

Resumo rápido
- Este é um aplicativo console .NET 8.0. Para ver o programa rodando execute: `dotnet run --project PaymentGateway.csproj`.

Pré-requisitos
- .NET SDK 8.0+ instalado (verifique com `dotnet --info`).

Comandos rápidos (terminal)

- Compilar e executar (modo padrão):
  ```bash
  dotnet run --project PaymentGateway.csproj
  ```
- Apenas compilar:
  ```bash
  dotnet build
  ```
- Executar o binário compilado (Debug):
  ```bash
  dotnet bin/Debug/net8.0/PaymentGateway.dll
  ```
- Executar em Release:
  ```bash
  dotnet run -c Release --project PaymentGateway.csproj
  ```
- Restaurar pacotes (se necessário):
  ```bash
  dotnet restore
  ```

Executando a aplicação (o que o projeto já faz)
- `Program.cs` contém chamadas de exemplo para os gateways embarcados: **pagseguro**, **mercadopago** e **stripe**.
- Executando `dotnet run --project PaymentGateway.csproj` você verá as validações e os logs de transação já configurados no código.

Exemplo de saída esperada
```
=== Sistema de Pagamentos Multi-Gateway ===

PagSeguro: Validando cartão...
PagSeguro: Processando R$ 150.00...
[PagSeguro] ... Transação concluída ...
...
[Erro] Gateway 'paypal' não suportado. Disponíveis: pagseguro, mercadopago, stripe
```

Rodando pelo VS Code (GUI)
1. Abra a pasta `root` no VS Code.
2. Instale a extensão **C#** se for sugerida.
3. Abra `Program.cs` e pressione **F5** (depurar) ou **Ctrl+F5** (rodar sem depurar).

Dicas e resolução de problemas ⚠️
- `dotnet: command not found` → instale o .NET SDK (https://dotnet.microsoft.com/download).
- Erro de build → execute `dotnet build` e cole o erro aqui para eu ajudar.
- Gateway não suportado → o app lança `NotSupportedException` com lista de nomes válidos (ex.: `pagseguro, mercadopago, stripe`).