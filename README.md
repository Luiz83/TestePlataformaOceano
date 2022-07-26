# TestePlataformaOceano

 Projeto desenvolvido para demonstrar minhas habilidades conforme o desafio proposto: 
 
 A partir de um input de um arquivo de log de uma corrida de kart, montar o resultado da corrida com as seguintes informações: Posição Chegada, Código Piloto, Nome Piloto, Qtde Voltas Completadas e Tempo

### Começando

 Para facilitar o teste, no mesmo repositório do projeto, deixei pronto um arquivo .xlsx com as mesmas informações propostas.

 - [Planilha com o log para teste](https://github.com/Luiz83/TestePlataformaOceano/blob/master/logCorrida.xlsx)

 Para iniciar o teste é necessário fazer o clone do projeto em um diretório de sua preferência:
```shell
cd "diretorio de sua preferencia"
git clone https://github.com/Luiz83/TestePlataformaOceano
```

Também fiz o deploy do projeto usando o heroku, podendo testar também através do link abaixo.

- [Link do projeto no heroku](https://personal-portfolio-deploy.herokuapp.com/swagger/index.html)

É normal a primeira chamada da API demorar um pouco mais, o heroku tem um code start que sobe a aplicação quando for solicitado, já que é uma ferramenta free eles derrubam a aplicação quando não está sendo usado.


 ## Desenvolvimento

 A partir da proposta do desafio, interpretei que o arquivo de log poderia ser no formato .xlsx por isso deixei pronta a planilha com os dados disponibilizados pelo outro arquivo.

 A respeito da imutabilidade, apliquei nas classes de forma que suas propriedades tenham seu set privado e sejam definidas pelo construtor e que não sejam alteradas em outro momento.

 Arquitetei o projeto em camadas, porém não vi a necessidade de utilizar repositórios, pois, no contexto proposto não utilizei um banco de dados então não tinha a necessidade de uma camada de acesso a dados. Utilizei somente a camada de Application que fica responsável pela lógica de tratar o input da planilha, analisar as informações e devolver como esperado.



