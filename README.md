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

	    selecione o player > add componente > Rigidibory

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

<br>
FAZER COM QUE A CAMERA SIGA O PLAYER
<br>

1) Movendo a câmera para seguir o jogador

        Main Camera > Transform Position =   X  0 , Y 10  e  Z -10
        Main Camera > Transform rotation =   X  45 , Y 0  e  Z 0

2) Adicione o componete a camera 	

        create new script > chamado "CameraController"

3) Escreva um script CameraController

        public class CameraController : MonoBehaviour
        {
            private GameObject player;
            private Vector3 offset;
            void Start()
            {
                offset = transform.position - player.transform.position;
            }

            void LateUpdate()
            {
                transform.position = player.transform.position + offset;
            }
        }

4) Referenciar o GameObject do jogador

       Unity > Selecione a Camera >  Em player None (Game Object) > Anexar o Player

<br>
CONFIGURAÇÃO DA ÁREA DO JOOGO
<br>

1) Crie uma parede para o campo de jogo

       crie um Empaty Game Object > chame de WALLS	
       
       create > 3d objecto > cubo > nomei para west wall
       position > X  -10  ,  Y  0  , Z  0
       scale    > X  0.5  ,  Y  2  , Z  20.5 
       adicione um material nesse objeto com a cor desejada
       
       criar os wall refente ao lados oeste, north e south ate fechar um quadro no plano com paredes
       
       arraste todos as paredes para o Empaty Game Object walls
       
       
       
       


