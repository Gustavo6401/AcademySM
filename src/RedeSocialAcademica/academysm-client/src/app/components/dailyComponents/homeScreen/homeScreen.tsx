import './homeScreen.css'

interface HomeScreenProperties {
    createCall: () => Promise<any>
    startHairCheck: (url: any) => Promise<void>
}

const HomeScreen: React.FC<HomeScreenProperties> = ({ createCall, startHairCheck }) => {
    {/* Ainda farei algumas alterações, dentre elas, pretendo fazer com que apenas professores possam iniciar
        vídeoconferências. */}
    const startDemo = () => {
        createCall().then((url) => {
            startHairCheck(url)
        })
    }

    return (
        <div className='home-screen'>
            <h1>Bem-Vindo ao Nosso Sistema de Vídeoconferências!</h1>
            <button onClick={startDemo} type='button'>
                Começar Vídeo Conferência
            </button>
        </div>
    )
}

export default HomeScreen