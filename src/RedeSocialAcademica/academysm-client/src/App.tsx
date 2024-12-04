import { useEffect, useState } from 'react'
import CadastroUsuario from './app/pages/cadastroUsuario/Index.js'
import PasswordGenerator from '../src/app/pages/passwordGenerator/Index'
import Login from '../src/app/pages/login/Index'
import Grupos from './app/pages/grupos/Index.js'
import GruposHomePage from '../src/app/pages/gruposHome/index.js'
import Tarefa from '../src/app/pages/tarefa/tarefa.js'
import './App.css'
import DetalhesUsuario from './app/pages/detalhesUsuario/Index'
import Videoconference from '../src/app/pages/videoconference/Videoconference.js'
import Tarefas from '../src/app/pages/tarefas/Tarefas.js'
import Privacidade from './app/pages/privacidade/Privacidade.jsx'
import Vendas from './app/pages/vendas/Vendas.jsx'
import UserProfile from './app/pages/portfolio/Portfolio.js'
import CreateUser from './app/pages/createUser/createUser.js'
import './Spaces.css'

function App() {
    const[Component, setComponent] = useState(() => Vendas)

    const navigation = (path: string) => {      
        let Component

        // Verifies Whether we have more digits in the URL after /DetalhesUsuario, using the flag d+$
        const userProfileRegex: RegExp = /^\/Portfolio\/[a-fA-F0-9-]+$/
        const userDetailsRegex: RegExp = /^\/DetalhesUsuario\/[a-fA-F0-9-]+$/
        const groupHomeRegex: RegExp = /^\/Grupos\/Home\/[a-fA-F0-9-]+$/
        const tarefasRegex: RegExp = /^\/Tarefas\/[a-fA-F0-9-]+$/
        const videoConferenciaRegex: RegExp = /^\/Videoconferencia\/[a-fA-F0-9-]+$/
        const tarefaRegex: RegExp = /^\/Tarefa\/[a-fA-F0-9-]+$/

        if (userDetailsRegex.test(path)) {
            Component = DetalhesUsuario
        } else if (userProfileRegex.test(path)) {
            Component = UserProfile
        } else if (groupHomeRegex.test(path)) {
            Component = GruposHomePage
        } else if (tarefasRegex.test(path)) {
            Component = Tarefas
        } else if (videoConferenciaRegex.test(path)) {
            Component = Videoconference
        } else if (tarefaRegex.test(path)) {
            Component = Tarefa
        }
        else {
            // Essa parte ficou uma merda.

            switch (path) {
                case '/CadastroDeUsuario':
                    Component = CreateUser
                    break
                case '/GeradorDeSenhas':
                    Component = PasswordGenerator
                    break
                case '/Grupos':
                    Component = Grupos
                    break
                case '/Login':
                    Component = Login
                    break
                case '/Privacidade':
                    Component = Privacidade
                    break
                case '/UserProfile':
                    Component = UserProfile
                    break
                case '/':
                default:
                    Component = Vendas
                    break

            }
        }      

        setComponent(() => Component)
    }

    useEffect(() => {
        navigation(window.location.pathname)

        window.addEventListener('popstate', () => navigation(window.location.pathname))

        return () => {
            window.removeEventListener('popstate', () => navigation(window.location.pathname))
        }
    }, [])
    

    return (
        <div>
            <Component />
        </div>
    )
}

export default App
