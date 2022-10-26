# programando jogo unity onde deve-se controlar a bola para coletar os pontos


create new project 3d URP

    criar uma nova cena > file  > new scene 
    file > save as > criei uma pasta chamada scena > der o nome para sua cena
    
    
1) Crie um plano primitivo
    
       gameObjectos > 3d object > plane
       nomeie para Ground
    
2) Crie um GameObject de jogadores
 
       gameObjectos > 3d object > Sphere
       nomeie para Player
     
3) Adicione cores com materiais
 
       cria um pasta > Material
       selecione a pasta > create > Material
       De o nome para o novo material e escolha uma cor para ele
       Arraste esse material para o objeto desejado
<br>     
MOVEMENTANDO JOGADOR ATRAVES DA INSTALAÇÃO DO PACOTE DE SISTEMA DE ENTRADA
<br>

1) Adicione um RigidBody ao Player

2) Instale o pacote do sistema de entrada

	   Windows >  Package Manager > Select All Package Manager > Input System > Install

3) Adicione um componente de entrada do jogador

	    Selecioner o player> add componente > Player Input > Create Action >  
	    Create new fold chamada "Inputs" > Selecione a pasta e salva o arquivo

4) Crie um novo script

	    Crie pasta "Scripts" > crie script c# chamado "PlayerController" e anexe ao Player

5) Escreva a declaração de função OnMove

	    Using UnityEngine.InputSystem;

        void OnMove(InputValue movementValue)
        {
        }

6) Aplique dados de entrada ao Jogador

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void OnMove(InputValue movementValue)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
        }

7) Aplique força ao Jogador FixeUpdate

        private Rigidbody rb;
        private float movementX;
        private float movementY;

        void OnMove(InputValue movementValue)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();

            movementX = movementVector.x;
            movementY = movementVector.y;
        }

        void FixedUpdate()
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement);
        }

8) Velocidade de movimento do jogador

        public float speed = 0.0f;

        void FixedUpdate()
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }

