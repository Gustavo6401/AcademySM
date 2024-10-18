import React, { useEffect, useState } from 'react';
import Navbar from '../../components/navbar/index'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-icons/font/bootstrap-icons.css'
import './Index.css'
import CourseComponent from '../../components/courseComponent/Index';
import NavbarWhite from '../../components/navbarWhite/Index';
import GroupViewServices from '../../services/groupViewServices'

export default function Grupos() {
    /** @type {Array<GroupViewModel>} */
    const [groups, setGroups] = useState(undefined)

    /** @type {GroupViewServices} */
    const services = new GroupViewServices()

    useEffect(() => {
        const fetchGroups = async () => {
            /** @type {Array<GroupsViewModel>} */
            const groups = await services.groups()

            setGroups(groups)
        }

        fetchGroups()
    }, [])

    return (
        <div>
            <NavbarWhite />
            <div className='groupsDiv'>
                <div className='grupos gruposCenter'>
                    <h1>Meus Grupos</h1>
                    <hr />
                    <div className='groupComponent'>
                        <div className='groupIconCircle'>
                            <i className="bi bi-music-note-beamed"></i>
                        </div>
                        <div className='groupDetailsComponent'>
                            <h1>Curso B�sico de Canto L�rico</h1>
                            <h2>N�vel: B�sico</h2>
                            <label>55% Conclu�do - +500 XP pelo Curso</label>
                        </div>
                    </div>
                    <div className='groupComponent'>
                        <div className='groupIconCircle'>
                            <i className="bi bi-hourglass-split"></i>
                        </div>
                        <div className='groupDetailsComponent'>
                            <h1>Curso de Hist�ria do Mundo</h1>
                            <h2>N�vel: B�sico</h2>
                            <label>55% Conclu�do - +200 XP pelo Curso</label>
                        </div>
                    </div>
                    <div className='groupComponent'>
                        <div className='groupIconCircle'>
                            <i className="bi bi-cpu-fill"></i>
                        </div>
                        <div className='groupDetailsComponent'>
                            <h1>TDD - Test Driven Development</h1>
                            <h2>N�vel: Intermedi�rio</h2>
                            <label>90% Conclu�do - +1000 XP pelo Curso</label>
                        </div>
                    </div>
                    <div className='groupComponent'>
                        <div className='groupIconCircle'>
                            <i className="bi bi-translate"></i>
                        </div>
                        <div className='groupDetailsComponent'>
                            <h1>Curso Avan�ado de Ingl�s</h1>
                            <h2>N�vel: Avan�ado</h2>
                            <label>90% Conclu�do - +1000 XP pelo Curso</label>
                        </div>
                    </div>
                    <div className='groupComponent'>
                        <div className='groupIconCircle'>
                            <i class="bi bi-pencil-fill"></i>
                        </div>
                        <div className='groupDetailsComponent'>
                            <h1>Desenhe Seus Pr�prios Retratos</h1>
                            <h2>N�vel: Intermedi�rio</h2>
                            <label>75% Conclu�do - +500 XP pelo Curso</label>
                        </div>
                    </div>
                </div>
                <div className='batePaposEmGrupo'>
                    <CourseComponent icon='bi bi-music-note-beamed' course='Canto L�rico' />
                    <CourseComponent icon='bi bi-hourglass-split' course='Hist�ria do Mundo' />
                    <CourseComponent icon='bi bi-cpu-fill' course='TDD - Test Driven Development' />
                    <CourseComponent icon='bi bi-translate' course='Ingl�s Avan�ado' />
                    <CourseComponent icon='bi bi-pencil-fill' course='Desenhe Seus Retratos' />
                </div>
            </div>
        </div>
    );
}