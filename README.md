# WE2002 Master Liga Opções v4.5

**Editor de Dinheiro e Contratações da Master Liga do Winning Eleven 2002 (PS1)**

**Desenvolvido por Fabio FJA | C# | Windows Forms | .NET Framework 4.8**

## Sobre o projeto

WE2002 Master Liga Opções v4.5 é uma ferramenta de edição e personalização do Winning Eleven 2002 para PlayStation 1 (PSX), desenvolvida em C# utilizando Windows Forms.

O programa permite modificar dois dos principais parâmetros da Master Liga: a quantidade de créditos disponíveis e o limite de contratações de jogadores.

Por meio de uma interface gráfica, o usuário pode selecionar valores personalizados, visualizar as configurações existentes e aplicar modificações diretamente ao arquivo BIN do jogo.

A ferramenta utiliza técnicas de engenharia reversa e manipulação binária, alterando offsets específicos para modificar limitações internas do Winning Eleven 2002 sem a necessidade de um editor hexadecimal externo.

## Funcionalidades

### 1. Editor de dinheiro da Master Liga

Permite personalizar a quantidade inicial de créditos disponíveis na Master Liga.

**Recursos:**
- Configuração de valores entre 0 e 9.999 créditos.
- Seleção de valores por meio de uma lista suspensa.
- Leitura da quantidade de créditos armazenada no arquivo BIN.
- Gravação direta do valor selecionado.
- Modificação de um parâmetro interno relacionado ao suporte a valores de quatro dígitos.
- Botão independente para salvar as configurações de dinheiro.

O editor utiliza um valor inteiro de 16 bits para representar a quantidade de créditos, permitindo substituir a configuração original por valores personalizados.

### 2. Editor de contratações da Master Liga

Permite modificar o limite de contratações de jogadores.

**Recursos:**
- Configuração de valores entre 0 e 255.
- Seleção individual do limite desejado.
- Leitura do valor existente no arquivo BIN.
- Alteração direta do parâmetro responsável pelo limite de contratações.
- Botão independente para salvar a configuração.

Essa funcionalidade possibilita experimentar uma Master Liga com limites de contratações diferentes dos definidos originalmente.

### 3. Leitura automática das configurações

Ao selecionar o arquivo BIN, o programa:

- Localiza os offsets responsáveis pelo dinheiro e pelas contratações.
- Lê os valores armazenados.
- Apresenta os resultados nos campos correspondentes.
- Habilita os controles de edição.

Isso permite consultar as configurações existentes antes de realizar modificações.

### 4. Restauração dos valores originais

O programa inclui o botão **Original**, responsável por restaurar os parâmetros modificados pelo editor.

A operação define:

- Dinheiro: 20 créditos.
- Contratações: 2.
- Parâmetro de representação de créditos: valor hexadecimal original `0x03`.

A restauração é realizada diretamente no arquivo BIN selecionado.

### 5. Interface gráfica

- Interface desenvolvida com Windows Forms.
- Botão **ISO** para selecionar arquivos BIN.
- Exibição do caminho do arquivo selecionado.
- Dois campos independentes para dinheiro e contratações.
- Botões individuais para salvar as modificações.
- Botão de restauração dos valores originais.
- Mensagens de confirmação das operações.
- Janela **About** com informações do desenvolvedor.
- Controles de edição inicialmente desabilitados até a seleção do arquivo.

### 6. Edição binária por offsets

O programa modifica diretamente posições específicas da imagem BIN do Winning Eleven 2002.

**Offsets utilizados (decimais):**

| Offset | Finalidade |
|---|---|
| 3266428 | Quantidade de créditos |
| 3266540 | Limite de contratações |
| 3305232 | Parâmetro relacionado à representação dos créditos |

A manipulação dos dados é realizada utilizando `FileStream`, com operações de leitura, posicionamento e escrita de bytes.

## Tecnologias utilizadas

- **Linguagem:** C#
- **Framework:** .NET Framework 4.8
- **Interface gráfica:** Windows Forms
- **Ambiente de desenvolvimento:** Microsoft Visual Studio
- **Manipulação binária:** FileStream
- **Conversão de dados:** BitConverter
- **Plataforma:** Microsoft Windows
- **Jogo:** Winning Eleven 2002 para PlayStation 1

## Estrutura do projeto

```text
WE2002-Master-Liga-Opcoes-4.5/
│
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
│
├── binEditor.cs
│
├── AboutBox1.cs
├── AboutBox1.Designer.cs
├── AboutBox1.resx
│
├── Program.cs
├── App.config
│
├── Properties/
│
├── WE2002-Master-Liga-Opcoes-4.5 by fja.csproj
├── WE2002-Master-Liga-Opcoes-4.5 by fja.slnx
│
└── bin/
    └── Debug/
        └── WE2002-Master-Liga-Opcoes-4.5 by fja.exe
```

## Como utilizar

1. Execute o programa no Windows.
2. Clique no botão **ISO**.
3. Selecione o arquivo BIN do Winning Eleven 2002.
4. O editor apresentará os valores de dinheiro e contratações existentes.
5. Escolha a quantidade desejada de créditos, entre 0 e 9.999.
6. Clique em **Salvar** na seção de créditos.
7. Escolha o limite de contratações, entre 0 e 255.
8. Clique em **Salvar** na seção de contratações.
9. Caso deseje restaurar as configurações originais, clique em **Original**.

## Requisitos

- Microsoft Windows.
- .NET Framework 4.8.
- Arquivo BIN compatível do Winning Eleven 2002.

## Observações importantes

- Faça uma cópia de segurança do arquivo BIN antes de utilizar o programa.
- As alterações são gravadas diretamente no arquivo selecionado.
- O programa não possui backup automático.
- O botão Original restaura apenas os parâmetros administrados pela ferramenta.
- Os offsets foram definidos para uma estrutura específica do jogo.
- Não existe validação automática da versão do arquivo BIN.
- O programa não modifica jogadores, uniformes, estádios ou outras configurações da Master Liga.

## Objetivo do projeto

Demonstrar a aplicação de técnicas de engenharia reversa, manipulação de arquivos binários e desenvolvimento de interfaces gráficas para criação de ferramentas de modificação de jogos clássicos.

O projeto também busca ampliar as possibilidades de personalização da Master Liga do Winning Eleven 2002.

## Créditos

**Desenvolvimento e programação:** Fabio FJA

**Projeto:** Fabio FJA Tools

**Versão do editor:** 4.5

**Data informada no projeto:** 26/04/2026

**Linguagem:** C#

**Framework:** .NET Framework 4.8

**Jogo:** Winning Eleven 2002

**Plataforma do jogo:** PlayStation 1

Projeto independente desenvolvido para estudo, pesquisa, engenharia reversa e personalização de jogos clássicos de futebol.

Este projeto não possui vínculo oficial com a Konami.
