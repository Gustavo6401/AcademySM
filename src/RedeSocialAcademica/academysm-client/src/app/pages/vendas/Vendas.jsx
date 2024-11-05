import React, { useEffect } from 'react';
import Navbar from '../../components/navbar/index'
import navigateTo from '../../../infra/navigation/navigation.ts'
import telaLogin from '../../assets/image/Tela de Login - Celular.webp'
import telaGrupos from '../../assets/image/Tela de Grupos - Computador.webp'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-icons/font/bootstrap-icons.css'
import './Vendas.css'

function Vendas() {
    /** 
     * @param {string} url
     */
    function navigate(url) {
        navigateTo(url)
    }

    return (
        <div>
            <Navbar />
            <div className='vendasTitle'>
                <div className='vendasMainContent'>
                    <h1><b>Aprenda Qualquer Coisa</b></h1>
                    <p>A Academy SM é um lugar na Internet onde você pode aprender o que quiser, aqui temos especialistas das mais diversas áreas de atuação e tudo o que você precisa é se cadastrar no curso dele.</p>
                    <p>Aqui também é o local para você educador, ou Instituição de Ensino Técnico ou Superior contribuir com a educação, então não perca tempo e fale com a nossa equipe!</p>
                    <button className='vermelho'>Converse com a Nossa Equipe!</button>
                    <button className='cinza' onClick={() => navigate('/CadastroDeUsuario')}>Faça Já o Cadastro</button>
                </div>
                <div className='vendasMainContentImages'>
                    <img className='mobileScreen' src={telaLogin} />
                    <img className='desktopScreen' src={telaGrupos} />
                </div>
            </div>
            <div className='vendasMainContentTwo'>
                <h1><b>Aprenda Qualquer Coisa</b></h1>
                <div className='vendasPossibleSkills'>
                    <div className='skill-component'>
                        <i className='bi bi-translate'></i>
                        <label>Inglês</label>
                    </div>
                    <div className='skill-component'>
                        <i className='bi bi-music-note-beamed'></i>
                        <label>Canto</label>
                    </div>
                    <div className='skill-component'>
                        <i className='bi bi-pencil-fill'></i>
                        <label>Desenho</label>
                    </div>
                    <div className='skill-component'>
                        <i className='bi bi-hourglass-split'></i>
                        <label>História</label>
                    </div>
                    <div className='skill-component'>
                        <i className='bi bi-code'></i>
                        <label>Programação</label>
                    </div>
                </div>                
            </div>
            <div className='vendasActualFeatures'>
                <h1><b>A Melhor Solução para o Conhecimento</b></h1>
                <p>Solução feita tanto para faculdades quanto para todos aqueles que abraçam e propagam a educação pelo mundo. Atualmente, temos as seguintes features:</p>
                <ol>
                    <li>Sistema de Vídeoconferências</li>
                    <li>Sistema de Envio de Tarefas</li>
                </ol>
            </div>
            <div className='vendasFooter' id='vendasFooter'>
                <h1><b>Não Perca Tempo!</b></h1>
                <div>Converse Já com a Nossa Equipe por meio do formulário.</div>
                <iframe className='vendasFormulario' src="https://docs.google.com/forms/d/e/1FAIpQLSegM9YedC8Xc6ELGGA3EUsLxGZpMn7xFXoLDzpIKv9-5-68gg/viewform?embedded=true" frameborder="0" marginheight="0" marginwidth="0">Loading…</iframe>
            </div>
        </div>
    );
}

export default Vendas;