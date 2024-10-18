import React from 'react';
import './Index.css'

export default function GroupsNavbar() {
    return (
        <section className='groupsPcButtons'>            
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-pencil-fill'></i>  Postagens
                </button>
            </div>
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-book-fill'></i>  Artigos
                </button>
            </div>
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-clipboard2-check-fill'></i>  Tarefas
                </button>
            </div>
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-question-lg'></i>  Dúvidas
                </button>
            </div>
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-folder-fill'></i>  Conteúdo do Curso
                </button>
            </div>
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-megaphone-fill'></i>  Avisos
                </button>
            </div>
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-chat-fill'></i>  Chat
                </button>
            </div>
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-person-fill'></i>  Turma
                </button>
            </div>
            <div className='componentIsolator-1'>
                <button className='buttonGroups'>
                    <i className='bi bi-record-circle'></i>  Vídeoconferência
                </button>
            </div>            
        </section>
    );
}