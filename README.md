# API de Biblioteca

Este projeto é uma API RESTful para gerenciar uma biblioteca. Ele abstrai modelos para Livros, Leitores e Locações.

## Modelos

- **Livro**: Contém informações sobre livros individuais na biblioteca.
- **Leitor**: Contém informações sobre os leitores que alugam livros.
- **Locação**: Registra quais leitores alugaram quais livros e quando.

## Endpoints

Esta API contém os métodos básicos GET, PUT, POST e DELETE para cada modelo.

### Exemplos:

- `GET /livros` - Retorna todos os livros
- `POST /leitores` - Cria um novo leitor
- `PUT /locacoes/{id}` - Atualiza informações de uma locação existente
- `DELETE /leitores/{id}` - Exclui um leitor

## Métodos de Filtro Adicionais

Além dos métodos básicos, a API também oferece métodos de filtro:

- `GET /locacoes/Livro/{livroId}` - Retorna todos os leitores que alugaram um livro específico.

---

## Como executar este projeto no Visual Studio 2022

1. Abra o Visual Studio 2022 e vá para `File > Open > Project/Solution` para abrir o projeto.
2. Restaure as dependências necessárias: `Tools > NuGet Package Manager > Manage NuGet Packages for Solution`.
3. Compile o projeto: `Build > Build Solution`.
4. Execute o projeto clicando no botão "Run" (ícone de "play" verde) na barra de ferramentas ou vá para `Debug > Start Debugging`.


---

## Contribuição

Sinta-se à vontade para contribuir com este projeto. Todas as contribuições são bem-vindas!

---

## Licença

Este projeto está sob a licença MIT.
