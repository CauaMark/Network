Network Connection - Processo Seletivo Benner

Este projeto foi desenvolvido como parte do processo seletivo da Benner. Ele implementa um sistema de rede de conexões entre elementos, permitindo criar conexões, desconectar elementos, verificar a existência de conexões diretas ou indiretas e calcular a quantidade mínima de conexões entre dois elementos.

📌 Funcionalidades

✅ Criar uma rede de elementos: O sistema permite definir um número máximo de elementos e gerenciar suas conexões.

✅ Conectar elementos: Dois elementos podem ser conectados diretamente.

✅ Desconectar elementos: Remove a conexão entre dois elementos, caso exista.

✅ Verificar conexão entre elementos:

Retorna true se os elementos estiverem direta ou indiretamente conectados.

Retorna false se não houver conexão.

✅ Determinar o nível de conexão entre dois elementos:

Retorna 0 se não houver conexão.

Retorna 1 se houver uma conexão direta.

Retorna 2 ou mais se a conexão for indireta (através de outros elementos).

✅ Interface de console interativa: Permite que o usuário interaja com a rede dinamicamente.

🚀 Tecnologias Utilizadas

C# (.NET)

Estruturas de Dados: Dictionary, HashSet, Queue

Algoritmos de Busca: Busca em Largura (BFS) para encontrar caminhos mínimos.


📄 Implementação Técnica

🔹 Estrutura de Dados

Dictionary<int, HashSet<int>> connections: Armazena os elementos e suas conexões.

HashSet<int>: Usado para evitar duplicatas nas conexões.

🔹 Principais Métodos

🔹 Connect(int num1, int num2)

Conecta dois elementos, garantindo que não haja duplicatas.

🔹 Disconnect(int num1, int num2)

Remove uma conexão entre dois elementos, se existir.

🔹 Query(int num1, int num2)

Verifica se dois elementos estão conectados direta ou indiretamente, utilizando Busca em Largura (BFS).

🔹 LevelConnection(int num1, int num2)

Determina o nível mínimo de conexão entre dois elementos, utilizando uma fila (Queue) para BFS.
