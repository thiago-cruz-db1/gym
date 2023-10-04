## ticket gate   
* catraca deve ter a relação de user permitidos apenas daquele dia
* catraca deve gerar um insert na minha base principal diariamente por jobs 
* qualquer catraca deve permitir a entrada do user valido
* qualquer catraca deve barrar a entreda do user invalido
* user deve fazer a entrada na academia por meio de um qrcode
  * qrcode deve estar em um toten e o user deve mirar o telefone e assim geerar uma tela verde liberando a passagem
  * qrcode deve fazer um post na entidade ticket gate na catraca com 
    * userid, 
    * ticket gate id, 
    * start at 
    * end at