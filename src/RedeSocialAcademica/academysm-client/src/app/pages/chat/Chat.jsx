import React from 'react';
import NavbarWhite from '../../components/navbarWhite/Index'
import GroupsNavbar from '../../components/groupsNavbar/Index'
import fotoGustavo from '../../assets/image/foto_gustavo.jpg'
import progresso from '../../assets/image/Evolucao Chess.com 12-08-2024.png'
import './Chat.css'

function ChatTitle({ icon, title }) {
    return (
        <div className='chatTitle'>
            <i className={icon}></i>
            <h1 className='TituloChat'>{title}</h1>
        </div>
    )
}

function ChatBody() {
    return (
        <div className='chatBody'>
            <div className='chatMyLonelyMessage'>
                <label>Olá Pessoal, tudo bem?</label>
            </div>
            <div className='rowItems'>
                <img className='itsProfilePic' src={fotoGustavo} />
                <div className='groupItsMessages'>
                    <div className='itsFirstMessage'>
                        <label>Olá, tudo bem?</label>
                    </div>
                    <div className='chatItsLastMessage'>
                        <label>O que deseja?</label>
                    </div>
                </div>
            </div>
            <div className='groupMyMessages'>
                <div className='myFirstMessage'>
                    <label>Eu queria Compartilhar Meu Progresso no Chess.com</label>
                </div>
                <div className='myLastMessage'>
                    <img className='chatMessageImage' src={progresso} />
                </div>
            </div>
        </div>
    )
}

function EnviarMensagem() {
    return (
        <div className='sendMessageComponent'>
            <input className='sendMessageInput' placeholder='Enviar Mensagem' />
            <button className='sendMessageButton'>
                <i className='bi bi-arrow-right-short'></i>
            </button>
        </div>
    )
}

function Chat() {
    return (
        <div>
            <NavbarWhite />
            <div className='chatPage'>
                <section className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </section>
                <div className='chat'>
                    <ChatTitle
                        icon={'bi bi-controller'}
                        title={'Curso Básico de Xadrez do 0 aos 1000 de Rating'}
                    />
                    <ChatBody />
                    <EnviarMensagem />
                </div>
            </div>
        </div>
    );
}

export default Chat;