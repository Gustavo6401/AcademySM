import React from 'react';
import NavbarWhite from '../../components/navbarWhite/Index'
import AcademySMText from '../../components/academySMText/Index';
import fotoGustavo from '../../assets/image/foto_gustavo.jpg'
import GroupsNavbar from '../../components/groupsNavbar/Index';
import LargeVotes from '../../components/largeVotes/Index'
import './Index.css'

export default function Duvida() {
    return (
        <div>
            <NavbarWhite />
            <div className='duvida'>
                <main className='duvidaMainComponent'>
                    <section className='perguntaDoUsuario'>
                        <LargeVotes numberVotes={5} />
                        <div className='contentDescription'>
                            <AcademySMText
                                title='Respondida'
                                text='Dicas para Jogar Xadrez Melhor \n Estou preso nos 1000 de rating e estou com dúvidas de como posso melhorar.'
                            />
                        </div>
                    </section>
                    <section className='writeYourResponse'>
                        <div className='escreverResposta'>
                            <img className='responseProfilePic' src={fotoGustavo} />
                            <button className='writeResponseButton'>
                                <label>Escreva Sua Resposta</label>
                            </button>
                        </div>
                    </section>
                    <section className='perguntaDoUsuario'>
                        <LargeVotes numberVotes={7} />
                        <div className='contentDescription'>
                            <AcademySMText
                                title='Melhor Resposta'
                                text='As Dicas que Funcionaram para mim são: \n 1 - Estude táticas: Táticas são essenciais no jogo de xadrez, o jogo de xadrez é essencialmente um jogo de cálculos.'
                            />
                        </div>                        
                    </section>
                </main>
                <div className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </div>
            </div>
        </div>
    );
}