# programando jogo unity onde deve-se controlar a bola para coletar os pontos

<br>  

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
       
<br> <br>      
MOVEMENTANDO JOGADOR ATRAVES DA INSTALAÇÃO DO PACOTE DE SISTEMA DE ENTRADA
<br><br>  

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

<br><br>  
FAZER COM QUE A CAMERA SIGA O PLAYER
<br><br>  

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

<br><br>  
CONFIGURAÇÃO DA ÁREA DO JOOGO
<br><br>  

1) Crie uma parede para o campo de jogo

       crie um Empaty Game Object > chame de WALLS	
       
       create > 3d objecto > cubo > nomei para west wall
       position > X  -10  ,  Y  0  , Z  0
       scale    > X  0.5  ,  Y  2  , Z  20.5 
       adicione um material nesse objeto com a cor desejada
       
       criar os wall refente ao lados oeste, north e south ate fechar um quadro no plano com paredes
       
       arraste todos as paredes para o Empaty Game Object walls
       
       
<br><br>  
CRIANDO INTENS COLECIONAVEIS
<br><br>  
       

1) Crie um GameObject colecionável

        crie um cubo
        adiconado material dar cor amarelo
        altere o posicionamento e a rotaçao

2) Gire o PickUp GameObject

        crie um script chamado "Rotator" anexa ao PickUp

        public class Rotator : MonoBehaviour
        {

            void Update()
            {
                transform.Rotate(new Vector3(15, 30, 5) * Time.deltaTime);
            }
        }

3) Faça pickup um Prefab

	    criar uma pasta chamada prefabs e arrastar o pickup para dentro

4) Adicione mais colecionáveis

	    Create Empaty Object chamado PickUp Parent
	    Arraste o objeto PickUp para dentro de PickUp Parent
	    Selecione o PickUp e duplique varios em volta do player
	    

<br><br>  
DETECTANDO COLISOES DO OBJETOS
<br><br>      

1) Desativar pickUps com OnTriggerEnter

        acesse o script do PlayerController para desabilitar o objeto

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.SetActive(false);
        }

2) Adicione uma tag ao Pré-Fabricado pickup

        selecione o objeto no pre fabricado
        insperctor> tag > add tag > crie um tag chamada "PickUp"
        selecione o objeto no pre fabricado > add a tag criada

3) Escreva uma declaração condicional

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
            }
        }

4) Defina os Colisores de Captação como gatilhos

	    selecione o objeto no pre fabricado e aplique o trigger
	    no seu componente box colide > marque a caixa "is trigger"

5) Adicione um componente rigidbody ao Pré-fabricador

	    selecione o objeto no pre fabricado
	    adicione o componente Rigidbory
	    desmaque a caixa de gravidade desse componente
	    habilite o is Kinematic

<br><br>  
INTERFACE DO USUARIO PARA EXIBIR PONTUAÇÃO
<br><br>     

1) Armazene o valor das PickUps coletadas

        no script playcontroller declarar uma variavel para contar os objetos
        inicie a variavel no metodo start e faça a contagem onde esta sendo
        verificado a colisão

        private int count;

        void Start()
        {
            count = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = +1;
            }
        }

2) Crie um elemento de texto de interface do usuário

        criar > UI > Text - Text Mash Pro
        Import TMP Enssentials
        Nomei para CountText

3) Exibir o valor da contagem

        abrar o script PlayerController

        public TextMeshProUGUI countText;

        void SetCountText()
        {
            countText.text = "Count " + count.ToString();
        }

        void Start()
        {
            SetCountText();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;

                SetCountText();
            }
        }

3) selecione o player na unity > seu componente > Script PlayerController

       arraste o CountText para dentro do none objetco refente ao couttext

4) No inspector do EventSystem do CountText

       click em > Replace with inputSystemUIInputMoudule

5) Crie uma mensagem final de jogo

        criar > UI > Text - Text Mash Pro
        Import TMP Enssentials
        Nomei para Win Text

6) Abra o script PlayerController

     public GameObject winTextObject;

        void Start()
        {
            winTextObject.SetActive(false);
        }

        void SetCountText()
        {
            countText.text = "Count " + count.ToString();
            if (count >= 8)
            {
                winTextObject.SetActive(true);
            }
        }

7) selecione o player na unity > seu componente > Script PlayerController

       arraste o Win Text para dentro do none objetco refente ao Win Text
       
       
<br>
TELA DE GAME OVER E RESERT ATRAVES DO DECTECTOR DE COLISÃO
<br>

1) Create um Carnva

	Create > UI > Image > Amplie a imagem ate cobrir todo cenario > chamar a imagem de game over
	selecione o image criado > create > UI > button > chamar o botao de Restart
	Deixar o gameoject criado da imagem desativado no inspector
	
2) create script para desativar e ativar objeto atrave de um Singleton

	Singleton é um design pattern usado quando você precisa chamar os métodos e variáveis
	de uma classe sem precisar declarar ela dentro de outra classe.

	create > gameobjeto > chamar esse gameobjet de "Game Controller"
	create > script > GameController.cs > anexar script no gameobjeto "Game Controller"
	
3)  GameController.cs criar um Singleton acessando variavel e metodo de outro script chamados pela vararivel criada instance;

	public class GameController : MonoBehaviour
	{
	    public static GameController instance;
	    
	    private void Awake()
	    {
		instance = this;
	    }
	}

4) Criar uma variavel publica gameOver e metodo ShowGameOver p/ referencia o objeto img gameover e ativalo ou desativalo
	
	public class GameController : MonoBehaviour
	{
	    public GameObject gameOver;
	    
	    public static GameController instance;
	    
	    private void Awake()
	    {
		instance = this;
	    }

	    public void ShowGameOver()
	    {
		gameOver.SetActive(true);
	    }
	}
	
5) Aplicar box colider nos objetos que será dectado a colisão e assim chamar o metodo ShowGameOver para ser ativado

	adicione um box colider nos walls 

6) create um novo script chamado DetectCollisions.cs anexando em cada objeto wall q será dectado a colisão
	
	criar metodo para detectar a colisão nos objetos, identificando quem ira colidir atraves da tag
	chamando o metodo ShowGameOver da class GameController atraves da instacia
	
	public class DetectedCollision : MonoBehaviour
	{
	    public void OnCollisionEnter(Collision collision)
	    {
		if (collision.gameObject.tag == "Player")
		{
		    //Debug.Log("Game Over");
		    GameController.instance.ShowGameOver();
		}
	    }
	}

7) Atribua o campo game objeto no objeto Game Controller

	Hierarchy > Game Controller > Componente Script GameController.cs > Campo Game Over > arrastar o img Game Over

8) Implementado a logica do RESERT utilizando o script GameController.cs
	
	Importar biblioteca para utilizaro restart
	criar uma o metodo restart
	
	
	using UnityEngine.SceneManagement;

	public void ResertGame()
        {
            //pegando a cena atual e recarregando ela
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
	
9) Referenciando o metodo resert no botao

	utilizar um unity event onclick para chamar um metodo ao ser clicado

	Hierarchy > Game Over > Button Resert > On Click > List Empty > add > arraste o Objeto Game Controller para referncia
	passe a função > None function > add GameController.cs > RestartGamer()

10) ADD Cena ao Scene in Build

File > Build Setting > Add Open Scenes > Procure a pasta Scena > Salva a scena e der um nome a ela
