namespace ExercicioModelagemDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
         /*


         Uma confecção deseja melhorar o controle dos produtos que produz, 
         seus clientes e os pedidos. Cada produto é caracterizado por nome, 
         categoria (ex. calça, camiseta, shorts, entre outros), tamanho, cor e seu 
         preço de custo. A categoria é uma classificação criada pela própria 
         confecção. A confecção possui informações sobre todos seus clientes. 
         Cada cliente é identificado por nome, endereço, telefones, RG e CPF. 
         Cada pedido possui o cliente, a data de elaboração do pedido, a data 
         prevista de entrega, o valor total, o status e os produtos. Por fim, cada 
         pedido pode conter um ou vários produtos, e para cada produto, indicase a quantidade solicitada.

         ❑ Faça o DER, o projeto lógico, o projeto lógico normalizado, o dicionário 
         de dados e o MER.






         ❑ Diagrama de Entidade-Relacionamento (DER):

          +-------------------+        +-----------------+
          |       Cliente     |        |     Produto     |
          +-------------------+        +-----------------+
          | Nome              |        | Nome            |
          | Endereço          |        | Categoria       |
          | Telefones         |        | Tamanho         |
          | RG                |        | Cor             |
          | CPF               |        | Preço de custo  |
          +--------+----------+        +-------+---------+
               |                          |
               |                          |
          +----+-------+           +------+--------+
          |   Pedido   |           |   ItemPedido  |
          +------------+           +---------------+
          | DataElaboracao        | Quantidade    |
          | DataEntrega            | PrecoUnitario |
          | ValorTotal             +---------------+
          | Status                 | PedidoID (FK) |
          | ClienteID (FK)         | ProdutoID (FK)|
          +------------+           +------+--------+

         ❑ Projeto Lógico:

         Cliente (ClienteID, Nome, Endereço, RG, CPF)
         Telefone (TelefoneID, ClienteID, Numero)
         Produto (ProdutoID, Nome, Categoria)
         Tamanho (TamanhoID, Tamanho)
         Cor (CorID, Cor)
         PrecoCusto (PrecoCustoID, ProdutoID, Valor)
         Pedido (PedidoID, DataElaboracao, DataEntrega, ValorTotal, Status, ClienteID)
         ItemPedido (ItemPedidoID, Quantidade, PrecoUnitario, PedidoID, ProdutoID)

         ❑ Projeto Lógico Normalizado:

         Cliente (ClienteID, Nome, Endereço, RG, CPF)
         Telefone (TelefoneID, ClienteID, Numero)
         Produto (ProdutoID, Nome, Categoria)
         Tamanho (TamanhoID, Tamanho)
         Cor (CorID, Cor)
         PrecoCusto (PrecoCustoID, ProdutoID, Valor)
         Pedido (PedidoID, DataElaboracao, DataEntrega, ValorTotal, Status, ClienteID)
         ItemPedido (ItemPedidoID, Quantidade, PrecoUnitario, PedidoID, ProdutoID)

         ❑ Dicionário de Dados:

         Cliente (tabela)
         - ClienteID: identificador único do cliente (inteiro)
         - Nome: nome do cliente (texto)
         - Endereço: endereço do cliente (texto)
         - RG: número do RG do cliente (texto)
         - CPF: número do CPF do cliente (texto)

         Telefone (tabela)
         - TelefoneID: identificador único do telefone (inteiro)
         - ClienteID: identificador único do cliente (inteiro)
         - Numero: número de telefone do cliente (texto)

         Produto (tabela)
         - ProdutoID: identificador único do produto (inteiro)
         - Nome: nome do produto (texto)
         - Categoria: categoria do produto (texto)

         Tamanho (tabela)
         - TamanhoID: identificador único do tamanho (inteiro)
         - Tamanho: tamanho do produto (texto)

         Cor (tabela)
         - CorID: identificador único da cor (inteiro)
         - Cor: cor do produto (texto)

         PrecoCusto (tabela)
         - PrecoCustoID: identificador único do preço de custo (inteiro)
         - ProdutoID: identificador único do produto (inteiro)
         - Valor: valor do custo do produto (decimal)

         Pedido (tabela)
         - PedidoID: identificador único do pedido (inteiro)
         - DataElaboracao: data de elaboração do pedido (data/hora)
         - DataEntrega: data prevista de entrega do pedido (data/hora)
         - ValorTotal: valor total do pedido (decimal)
         - Status: status do pedido (texto)
         - ClienteID: identificador único do cliente associado ao pedido (inteiro)
         - ItemPedido (tabela)
         - ItemPedidoID: identificador único do item do pedido (inteiro)
         - Quantidade: quantidade solicitada do produto (inteiro)
         - PrecoUnitario: preço unitário do produto no pedido (decimal)
         - PedidoID: identificador único do pedido associado ao item (inteiro)
         - ProdutoID: identificador único do produto associado ao item (inteiro)

         ❑ Modelo de Entidade-Relacionamento (MER):

                          +---------------------+
                          |       Cliente       |
                          +---------------------+
                          | ClienteID (PK)      |
                          | Nome                |
                          | Endereço            |
                          | RG                  |
                          | CPF                 |
                          +--------+------------+
                                   |
                                   |
                  +----------------+-----------------+
                  |                                  |
          +-------+--------+                +-------+--------+
          |    Telefone    |                |    Pedido      |
          +----------------+                +----------------+
          | TelefoneID (PK)|                | PedidoID (PK)  |
          | ClienteID (FK) |                | DataElaboracao |
          | Numero         |                | DataEntrega    |
          +----------------+                | ValorTotal     |
                                            | Status         |
                                            | ClienteID (FK) |
                                            +-------+--------+
                                                     |
                                                     |
                                           +---------+---------+
                                           |     ItemPedido    |
                                           +-------------------+
                                           | ItemPedidoID (PK) |
                                           | Quantidade        |
                                           | PrecoUnitario     |
                                           | PedidoID (FK)     |
                                           | ProdutoID (FK)    |
                                           +-------------------+
                                                |
                                                |
                                           +--------+-------+
                                           |     Produto    |
                                           +----------------+
                                           | ProdutoID (PK) |
                                           | Nome           |
                                           | Categoria      |
                                           +----------------+




             */
        }
    }
}