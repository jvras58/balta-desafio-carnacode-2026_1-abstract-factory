# Arquitetura — `PaymentGateway` ✅

Breve visão geral do projeto e como adicionar novos gateways sem tocar na lógica de negócio.

---

## Estrutura do projeto

```text
PaymentGateway/
│
├── Abstractions/               ← Contratos (interfaces)
│   ├── IPaymentFactory.cs      ← Abstract Factory
│   ├── IPaymentValidator.cs
│   ├── IPaymentProcessor.cs
│   └── IPaymentLogger.cs
│
├── Gateways/                   ← Implementações concretas por gateway
│   ├── PagSeguro/
│   │   ├── PagSeguroValidator.cs
│   │   ├── PagSeguroProcessor.cs
│   │   └── PagSeguroLogger.cs
│   ├── MercadoPago/
│   │   ├── MercadoPagoValidator.cs
│   │   ├── MercadoPagoProcessor.cs
│   │   └── MercadoPagoLogger.cs
│   └── Stripe/
│       ├── StripeValidator.cs
│       ├── StripeProcessor.cs
│       └── StripeLogger.cs
│
├── Factories/                  ← `IPaymentFactory` concreto por gateway
│   ├── PagSeguroFactory.cs
│   ├── MercadoPagoFactory.cs
│   └── StripeFactory.cs
│
├── Registry/
│   └── PaymentFactoryRegistry.cs  ← ponto único de resolução/registro
│
├── Services/
│   └── PaymentService.cs       ← opera apenas sobre abstrações
│
├── Program.cs
└── PaymentGateway.csproj
```

## Princípio arquitetural

- Padrão: **Abstract Factory** + registry central.
- Responsabilidade única: `PaymentService` orquestra o fluxo **usar abstrações** (`IPaymentValidator`, `IPaymentProcessor`, `IPaymentLogger`).
- Extensão sem modificação: para adicionar gateways você só adiciona classes/fábrica e registra (Open/Closed Principle).

> Observação: `PaymentService` não conhece implementações concretas — zero switch/case.

---

## Componentes (rápido)

- `Abstractions/` — contratos do domínio (fábrica + produtos: validator, processor, logger).
- `Gateways/` — implementação concreta por provedor (cada gateway tem suas 3 classes).
- `Factories/` — fábricas concretas que criam a família (validator, processor, logger).
- `Registry/PaymentFactoryRegistry.cs` — resolve ou registra fábricas por chave (ex: "stripe").
- `Services/PaymentService.cs` — usa `IPaymentFactory` para obter os componentes e executar: validar → processar → logar.

---

## Como adicionar um novo gateway (ex.: `PayPal`) 🚀

1. Criar pasta `src/Gateways/PayPal/` com as classes:
   - `PayPalValidator.cs`
   - `PayPalProcessor.cs`
   - `PayPalLogger.cs`
2. Criar `src/Factories/PayPalFactory.cs` que implemente `IPaymentFactory` e retorne as 3 instâncias.
3. Registrar no `PaymentFactoryRegistry` (arquivo `src/Registry/PaymentFactoryRegistry.cs`) — exemplo:

```csharp
// adicionar na inicialização do dicionário:
{ "paypal", new PayPalFactory() },

// ou em runtime (útil para plugins/testes):
PaymentFactoryRegistry.Register("paypal", new PayPalFactory());
```

4. Testar usando `PaymentFactoryRegistry.Resolve("paypal")` ou via `PaymentService` passando a factory resolvida.

> Resultado: `PaymentService` não precisa ser alterado — o novo gateway funciona imediatamente.

---

## Exemplo de uso rápido

```csharp
var factory = PaymentFactoryRegistry.Resolve("stripe");
var service = new PaymentService(factory);
service.ProcessPayment(100.00m, "4242424242424242");
```

---

## Convenções e boas práticas 💡

- Nomeie classes por gateway (`StripeProcessor`, `PagSeguroLogger`, etc.).
- Nunca exponha números de cartão em logs — use máscara (veja `PaymentService.Mask`).
- Use `PaymentFactoryRegistry.Register` em testes para sobrescrever fábricas.