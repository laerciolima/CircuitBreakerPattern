

# Exemplo de Implementação de Circuit Breaker com Polly em .NET 6

Este é um projeto de exemplo que demonstra como implementar um circuit breaker usando a biblioteca Polly em um aplicativo .NET 6.

## Descrição

Neste projeto, você encontrará um aplicativo de exemplo que faz chamadas a um serviço externo simulado. Utilizamos o Polly para implementar um circuit breaker que gerencia essas chamadas, protegendo o aplicativo de erros frequentes no serviço externo.

## Tecnologias Utilizadas

- .NET 6
- Polly
- Wiremock

## Configuração

Certifique-se de ter o SDK do .NET 6 instalado em sua máquina.

## Como Usar

1. Clone este repositório em sua máquina local:

```bash
git clone https://github.com/laerciolima/CircuitBreakerPattern.git
```

2. Navegue até o diretório do projeto:

3. Abra o projeto em seu ambiente de desenvolvimento (por exemplo, Visual Studio ou Visual Studio Code).

4. Execute o aplicativo. Ele fará chamadas simuladas ao serviço externo com as políticas do Polly para gerenciar possíveis falhas.

5. Há um arquivo docker-compose.yml na raiz do projeto com o container do wiremock com a rota configurada para erro 503

6. Explore o código-fonte para entender como o circuit breaker é configurado e usado em seu aplicativo.

## Contribuição

Fique à vontade para contribuir com melhorias, correções de bugs ou novos recursos. Abra uma solicitação de pull request e descreva suas alterações.

## Licença

Este projeto está licenciado sob a MIT License

## Contato

Se você tiver alguma dúvida ou sugestão, sinta-se à vontade para entrar em contato:

- Nome: Laercio Lima
- Email: llaercio.lima@gmail.com
- GitHub: [seu-usuario](https://github.com/seu-usuario)
