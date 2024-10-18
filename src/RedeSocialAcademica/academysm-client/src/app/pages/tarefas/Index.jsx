import React from 'react';
import Navbar from '../../components/navbar/index'
import GroupsNavbar from '../../components/groupsNavbar/Index';
import './Index.css'
import GroupDescription from '../../components/groupDescription/Index';

export default function Tarefas() {
    return (
        <div>
            <Navbar />
            <div className='aba-tarefas'>
                <main className='tarefas'>
                    <GroupDescription icon='bi bi-controller' courseTitle='Curso de Xadrez do 0 ao 1000 de Rating' percentageConcluded={90} />
                    <section className='tarefas-atrasadas'>
                        <h1>Atrasadas</h1>
                        <div className='tarefa-atrasada'>
                            <div className='tarefa-atrasada-button'>
                                <i className='bi bi-clipboard-check-fill'></i>
                            </div>
                            <div className='task-description'>
                                <h1>Aprenda a Abertura Ruy Lopez</h1>
                                <h2>Vale: 2,0</h2>
                                <label>Para: Dia 05/08/2024</label>
                            </div>
                        </div>                                
                    </section>
                    <section className='tarefas-abertas'>
                        <h1>Abertas</h1>
                        <div className='tarefa-aberta'>
                            <div className='tarefa-aberta-button'>
                                <i className='bi bi-clipboard-check-fill'></i>
                            </div>
                            <div className='task-description'>
                                <h1>Faça os Exercícios de Tática</h1>
                                <h2>Vale: 4,0</h2>
                                <label>Para: Dia 10/08/2024</label>
                            </div>
                        </div>
                    </section>
                    <section className='tarefas-enviadas'>
                        <h1>Enviadas</h1>
                        <div className='tarefa-enviada'>
                            <div className='tarefa-enviada-button'>
                                <i className='bi bi-clipboard-check-fill'></i>
                            </div>
                            <div className='task-description'>
                                <h1>Obter 800 de Rating</h1>
                                <h2>Vale: 2,0</h2>
                                <label>Para: Dia 10/08/2024</label>
                            </div>
                        </div>
                    </section>
                </main>
                <section className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </section>
            </div>
        </div>
    );
}