import './Index.css'
import NavbarWhite from '../../components/navbarWhite/Index.jsx';
import CourseComponent from '../../components/courseComponent/Index.tsx';
import { useEffect, useState } from 'react';
import GroupViewModel from '../../../domain/models/viewModels/groupViewModel.js';
import GroupViewServices from '../../services/groupViewServices.js';
import CreateGroupsModal from '../../modal/createGroups/CreateGroupsModal.js';

export default function Grupos() {
    const [groups, setGroups] = useState<Array<GroupViewModel> | undefined>(undefined)
    const [isModalOpen, setIsModalOpen] = useState(false)

    const services: GroupViewServices = new GroupViewServices()

    useEffect(() => {
        const fetchGroups = async () => {
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
                    <div className='createNewGroup'>
                        <button onClick={() => setIsModalOpen(true)} className='button-medium verde'>Cadastrar Novo Grupo</button>
                    </div>
                    <CreateGroupsModal
                        isOpen={isModalOpen}
                        onClose={() => setIsModalOpen(false)}
                    />
                    {groups ? groups.map(item => 
                        <div className='groupComponent'>               
                            <div className='groupIconCircle'>
                                <i className={`${item.getGroupCategoryIcon()}`}></i>
                            </div>
                            <div className='groupDetailsComponent'>
                                <h1>{item.getGroupTitle()}</h1>
                                <h2>{item.getGroupLevel()}</h2>
                            </div>
                        </div>
                    ) : "Carregando..."}
                </div>
                <div className='batePaposEmGrupo'>
                    <CourseComponent icon='bi bi-music-note-beamed' course='Canto Lírico' />
                    <CourseComponent icon='bi bi-hourglass-split' course='História do Mundo' />
                    <CourseComponent icon='bi bi-cpu-fill' course='TDD - Test Driven Development' />
                    <CourseComponent icon='bi bi-translate' course='Inglês Avançado' />
                    <CourseComponent icon='bi bi-pencil-fill' course='Desenhe Seus Retratos' />
                </div>
            </div>
        </div>
    )
}