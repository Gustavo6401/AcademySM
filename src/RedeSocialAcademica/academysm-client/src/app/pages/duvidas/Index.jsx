import React from 'react';
import Navbar from '../../components/navbar/index'
import GroupDescription from '../../components/groupDescription/Index'
import GroupsNavbar from '../../components/groupsNavbar/Index'
import fotoGustavo from '../../assets/image/foto_gustavo.webp'
import './Index.css'
import Question from '../../components/question/Index';

function Duvidas() {
    return (
        <div>
            <Navbar />
            <div className='duvidaPage'>
                <main className='duvidas'>
                    <GroupDescription
                        icon='bi bi-controller'
                        courseTitle='Curso de Xadrez: Do zero aos 1000 de Rating'
                        percentageConcluded={90}
                    />
                    <div className='duvidaMainContent'>
                        <section className='buscarDuvida'>
                            <div className='componentIsolator-1'>
                                <input className='formInputType-1' type='text' name='Nome' placeholder='Busque Aqui Sua Dúvida' />
                            </div>
                            <div className='componentIsolator-1'>
                                <select className='formInputType-1'>
                                    <option value='Respondida'>Respondida</option>
                                    <option value='Não Respondida'>Não Respondida</option>
                                </select>
                            </div>
                            <div className='componentIsolator-1'>
                                <button className='button-medium azul'>Aplicar Filtros</button>
                            </div>
                        </section>
                        <section className='fazerPergunta'>
                            <button className='button-xlarge verde'>Faça Sua Pergunta</button>
                        </section>
                    </div>
                    <section className='perguntas'>
                        <h2>Não Respondidas</h2>
                        <Question
                            questionTitle='Como Vocês Fizeram Para Chegar aos 1200 de Rating?'
                            questionDescription='Não Respondida'
                            questionMakerName='Gustavo da Silva Oliveira'
                        />
                    </section>
                    <section className='perguntas'>
                        <h2>Respondidas</h2>
                        <Question
                            questionTitle='Dicas Para Jogar Xadrez Melhor'
                            questionDescription='Respondida'
                            questionMakerName='Gustavo da Silva Oliveira'
                        />
                    </section>
                </main>
                <section className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </section>
            </div>
        </div>
    );
}

export default Duvidas;