import Navbar from '../../components/navbar/index'
import GroupsNavbar from '../../components/groupsNavbar/Index'
import './Index.css'
import AcademySMText from '../../components/academySMText/Index.tsx';
import { useEffect, useState } from 'react';
import Assignment from '../../../domain/models/apis/groups/assignment';
import TarefaViewServices from '../../services/tarefaViewServices';
import EnviarTarefa from '../../modal/sendAssignment/enviarTarefa';

export default function Tarefa() {
    const [isModalOpen, setIsModalOpen] = useState<boolean>(false)

    const [assignmentDetails, setAssignmentDetails] = useState<Assignment | undefined>(undefined)

    const pathParts: Array<string> = window.location.pathname.split('/')
    const tarefaId: string = pathParts[pathParts.length - 1]

    const services: TarefaViewServices = new TarefaViewServices()

    useEffect(() => {
        const handleAssignmentInfo = async () => {
            const assignments: Assignment = await services.get(tarefaId)

            setAssignmentDetails(assignments)
        }

        handleAssignmentInfo()
    }, [tarefaId])

    const Nota = () => {
        console.log(assignmentDetails?.getDueDate())

        return (
            <div>
                {assignmentDetails ?
                    <label className='fontMedium'>Para - Dia {new Date(assignmentDetails.getDueDate()).getDate()}/{new Date(assignmentDetails.getDueDate()).getMonth() + 1}/{new Date(assignmentDetails.getDueDate()).getFullYear()}  - Nota - {assignmentDetails.getNoteValue()}</label> :
                 ''}
            </div>
        )
    }

    const BotaoEnvio = () => {
        return (
            <div>
                <button className='button-medium vermelho' onClick={() => setIsModalOpen(true)}>
                    <i className='bi bi-file-earmark-plus-fill'></i> Adicionar Envio
                </button>
                <EnviarTarefa
                    isOpen={isModalOpen}
                    onClose={() => setIsModalOpen(false)}
                    tarefaId={tarefaId}
                />
            </div>
        )
    }

    return (
        <div>
            <Navbar />
            <div className='paginaTarefa'>
                <main className='taskPage'>
                    <section className='voltarAbaTarefas'>
                        <div className='fontExtraLarge'>
                            <i className='bi bi-clipboard-check-fill'></i>
                        </div>
                        <label className='fontMedium'>Voltar à Aba Tarefas</label>
                    </section>
                    <section>
                        {assignmentDetails ? 
                            <AcademySMText
                                title={assignmentDetails.getTitle()}
                                text=''
                                component1={<Nota />}
                                component2={<BotaoEnvio />}
                                component3={<></>}
                            /> : 'Carregando'}
                    </section>
                </main>
                <div className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </div>
            </div>
        </div>
    );
}