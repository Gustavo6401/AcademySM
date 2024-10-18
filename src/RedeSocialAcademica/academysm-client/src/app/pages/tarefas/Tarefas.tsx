import './Index.css'
import Navbar from '../../components/navbar/index.jsx'
import GroupDescription from '../../components/groupDescription/Index.tsx'
import GroupsNavbar from '../../components/groupsNavbar/Index.jsx'
import { useEffect, useState } from 'react'
import TarefasViewServices from '../../services/tarefasViewServices.js'
import Assignment from '../../../domain/models/apis/groups/assignment.js'
import CadastroTarefa from '../../modal/createAssignment/createAssignment.js'

function Tarefas() {
    const [isInstructor, setIsInstructor] = useState<boolean>(false)
    const [assignments, setAssignments] = useState<Array<Assignment>>(new Array<Assignment>())

    const [isModalOpen, setIsModalOpen] = useState<boolean>(false)

    const pathParts: Array<string> = window.location.pathname.split('/')
    const groupId: string = pathParts[pathParts.length - 1]

    const services: TarefasViewServices = new TarefasViewServices()

    const ProfessorInformation: React.FC = () => {
        if (isInstructor === false) {
            console.log('Aluno.')
            return <></>
        }
        console.log('Professor.')

        return (
            <div>
                <div className='createNewAssignment'>
                    <button className='button-medium verde' onClick={() => setIsModalOpen(true)}>Atribuir Tarefa</button>
                </div>
                <CadastroTarefa
                    isOpen={isModalOpen}
                    onClose={() => setIsModalOpen(false)}
                    groupId={groupId}
                />
            </div>
        )
    }

    useEffect(() => {
        const isProfessor = async () => {
            var result: boolean = await services.isProfessorAccessing(groupId)

            setIsInstructor(result)
        }

        isProfessor()
    }, [])

    useEffect(() => {
        const tasksData = async () => {
            var result: Array<Assignment> = await services.viewGroupTasks(groupId)

            setAssignments(result)
        }

        tasksData()
    }, [])

    return (
        <div>
            <Navbar />            
            <div className='aba-tarefas'>
                <main className='tarefas'>
                    <GroupDescription icon='bi bi-controller' courseTitle='Curso de Xadrez do 0 ao 1000 de Rating' percentageConcluded={90} />
                    <ProfessorInformation />
                    <section className='tarefas-atrasadas'>
                        <h1>Atrasadas</h1>
                    </section>
                    <section className='tarefas-abertas'>
                        <h1>Abertas</h1>
                        {assignments ? assignments.map(item =>
                            <div className='tarefa-aberta'>
                                <div className='tarefa-aberta-button'>
                                    <i className='bi bi-clipboard-check-fill'></i>
                                </div>
                                <div className='task-description'>
                                    <h1>{item.getTitle()}</h1>
                                    <h2>Vale: {item.getNoteValue()}</h2>
                                    <label>Para: Dia {new Date(item.getDueDate()).getDate()}/{new Date(item.getDueDate()).getMonth()}/{new Date(item.getDueDate()).getFullYear()}</label>
                                </div>
                            </div>
                        ) : 'Carregando...'}
                    </section>
                    <section className='tarefas-enviadas'>
                        <h1>Enviadas</h1>                        
                    </section>
                </main>
                <section className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </section>
            </div>
        </div>
    );
}

export default Tarefas;