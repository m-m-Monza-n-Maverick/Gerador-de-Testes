# Gerador de Testes

## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Descrição

Mariana prepara diversos exercícios para suas filhas que estão na 1ª e 2ª séries. Ela gostaria de informatizar esses exercícios, para gerar testes aleatórios. Cada teste  gerado deve ser guardado (acompanhado de suas questões), com a indicação de sua  data de geração. Na geração de um teste, é preciso informar o número de questões  desejadas e qual a disciplina pertence ao teste.

Para cada disciplina, cadastra-se: uma lista de questões objetivas, e matérias pertencentes. O gabarito também é  cadastrado a fim de facilitar a correção do teste. Cada matéria faz parte de uma única  disciplina. A série está ligada à matéria. 

## Funcionalidades

### Disciplina

1. O cadastro de **Disciplinas** consiste de:
    - nome

    1.1. O campo nome é obrigatório;
   
    1.2. Não pode registrar uma disciplina com o mesmo nome;
   
    1.3. A disciplina deve armazenar informações sobre as matérias que serão relacionadas à ela posteriormente;

    1.4. Não deve ser possível excluir disciplinas com matérias e testes relacionados.

### Matéria

2. O cadastro de **Matérias** consiste de:

    - Nome
    - Disciplina
    - Série

    2.1. Todos os campos são obrigatórios;
   
    2.2. Não pode registrar uma matéria com o mesmo nome;
   
    2.3. Não deve ser possível excluir matérias sendo utilizadas em questões.

### Questão

3. O cadastro de **Questões** consiste de:
    - Matéria
    - Enunciado
    - Alternativas

    3.1. Todos os campos são obrigatórios;
   
    3.2. Cada questão deve ter um mínimo e máximo de alternativas;

    3.3. Deve permitir adicionar alternativas à questão;

    3.4. Deve permitir remover alternativas à questão;

    3.5. Não permitir o cadastro de questões sem uma alternativa correta

    3.6. Não deve permitir o cadastro de mais de uma alternativa correta

    3.7. No mínimo duas alternativas devem ser configuradas

### Teste

4. O cadastro de **Testes** consiste de:
   - Título
   - Disciplina
   - Matéria*
   - Série
   - Quantidade de questões
     
   4.1. Deve ser informado a quantidade de questões que deverão ser geradas;

   4.2. Não pode registrar um teste com o mesmo nome;
   
   4.3. A quantidade de questões informada deve ser menor ou igual a quantidade de questões cadastradas;
   
   4.4. As matérias devem ser carregadas a partir da disciplina selecionada;
   
   4.5. Não deve permitir selecionar uma matéria que não pertença a disciplina selecionada;
   
   4.6. Caso a disciplina seja alterada, o campo matéria deve ficar em branco;
   
   4.7. Caso seja “Prova de Recuperação” deve considerar as questões de todas as matérias da disciplina selecionada;
   
   4.8. Todos os campos são obrigatórios;
   
   4.9. As questões devem ser selecionadas de forma aleatória;
   
   4.10. Deve permitir duplicar testes
   - Na duplicação do teste o título, disciplina, quantidade de questões, série, prova de recuperação e matéria deverão vir preenchidos
   - Não pode duplicar um teste com o mesmo nome
   - Na duplicação do teste, as questões devem vir em branco
   
   4.11. Deve ser possível visualizar os testes individualmente, com informações detalhadas incluindo as questões;
   
   4.12. Gerar PDF dos Testes.
   - O arquivo PDF do Teste deve apresentar: Título, Disciplina, Matéria, as questões e suas as alternativas
     
   4.13. Gerar PDF do Gabarito dos Testes.
   - O arquivo PDF do Gabarito do Teste deve apresentar: Título, Disciplina, Matéria, as questões e suas alternativas (com a alternativa correta assinalada)

---

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
---
## Como Usar

#### Clone o Repositório
```
git clone https://github.com/m-m-Monza-n-Maverick/Gerador-de-Testes.git
```

#### Navegue até a pasta raiz da solução
```
cd Gerador de Testes
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd Gerador_de_Testes.WinApp
```

#### Execute o projeto
```
dotnet run
```
