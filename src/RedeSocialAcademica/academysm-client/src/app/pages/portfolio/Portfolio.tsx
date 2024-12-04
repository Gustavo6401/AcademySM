import { useEffect, useState } from 'react';
import Navbar from '../../components/navbar';
import PortfolioViewServices from '../../services/portfolioViewServices';
import './Portfolio.css'
import UserPortfolio from '../../../domain/models/viewModels/portfolio/userPortfolio';
import PortfolioLink from '../../../domain/models/viewModels/portfolio/portfolioLink';
import ParticipantGroup from '../../../domain/models/viewModels/portfolio/participantGroup';
import PortfolioCourses from '../../../domain/models/viewModels/portfolio/portfolioCourses';
import navigateTo from '../../../infra/navigation/navigation';
import DeleteUserModal from '../../modal/deleteUser';

function goToWebsite(link: string): void {
    navigateTo(link)
}

function UserProfile() {
    const [userPortfolio, setUserPortfolio] = useState<UserPortfolio | undefined>(undefined)
    const [icons, setIcons] = useState<Array<string> | undefined>(undefined)
    const [isModalOpen, setIsModalOpen] = useState(false)

    const pathParts: Array<string> = window.location.pathname.split('/')
    const userId: string = pathParts[pathParts.length - 1]

    const applicationServices: PortfolioViewServices = new PortfolioViewServices()

    useEffect(() => {
        const fetchPortfolio = async () => {
            const portfolio: UserPortfolio = await applicationServices.portfolio(userId)
            setUserPortfolio(portfolio)

            const icon: Array<string> = portfolio.getLinks().map((link: PortfolioLink) =>
                applicationServices.correctIcon(link.getOrigin()))

            setIcons(icon)
        }

        fetchPortfolio()
    }, [])

    return (
        <div>
            <Navbar />            
            <div className='userProfile'>
                <div className='userProfile-coursesFormations'>
                    <div className='userProfile-myCourses'>
                        <h2>Cursos que Faço</h2>
                        {userPortfolio ? userPortfolio.getAcademySmGroups().map((participantGroup: ParticipantGroup) => {
                            if (participantGroup.getRole() !== 'Professor') {
                                /**
                                    * en-us 
                                    * asm means Academy SM 
                                    * 
                                    * pt-br
                                    * asm significa Academy SM.
                                * */
                                return <div className='userProfile-asmCoursesComponent'>
                                    <i className={participantGroup.getCategoryIcon()}></i>
                                    <h3>{participantGroup.getGroupName()}</h3>
                                </div>
                            }
                        }) : 'Carregando'}
                    </div>
                    <div className='userProfile-educationalBackgrounds'>
                        <h2>Formações</h2>
                        {userPortfolio ? userPortfolio.getCourses().map((courses: PortfolioCourses) =>
                            /** en-us Educational Backgrounds = pt-br Formações Acadêmicas. */
                            <div className='userProfile-educationalBackgrounds'>
                                <h3>{courses.getName()}</h3>
                            </div>
                        ) : 'Carregando'}
                    </div>
                </div>
                <div>
                    {userPortfolio ?
                        <div className='userProfile-curriculum'>
                            <img
                                src={`https://localhost:7231/api/Images?imageName=${userPortfolio.getProfilePic()}`}
                                alt='Foto de Perfil'
                                className='userProfile-profilePic'
                            />
                            <h1>{userPortfolio.getUserName()}</h1>
                            <h2>Currículo</h2>
                            <p>{userPortfolio.getCurriculum()}</p>
                        </div>
                     : 'Carregando'}
                </div>
                <div className='userProfile-coursesLinks'>
                    <div className='userProfile-myCourses'>
                        <h2>Cursos que Ministro</h2>
                        {userPortfolio ? userPortfolio.getAcademySmGroups().map((participantGroup: ParticipantGroup) => {
                            if (participantGroup.getRole() === 'Professor') {
                                return <div className='userProfile-asmCoursesComponent'>
                                    <i className={participantGroup.getCategoryIcon()}></i>
                                    <h3>{participantGroup.getGroupName()}</h3>
                                </div>
                            }
                        }) : 'Carregando'}
                    </div>
                    <div className='userProfile-links'>
                        <h2>Demais Perfis: </h2>
                        {userPortfolio ? userPortfolio.getLinks().map((portfolioLink: PortfolioLink, index: number) =>
                        {
                            /* 
                             * icons is a data structure based in userPortfolio.getLinks(). seealso useEffect() 
                             * method ahead
                             */
                            return <div className='userProfile-asmLinksComponent' onClick={() => goToWebsite(portfolioLink.getLink())}>
                                <i className={icons[index]}></i>
                                <h3>{portfolioLink.getName()}</h3>
                            </div>
                        }) : 'Carregando'}
                        <div>
                            <button
                                className='medium bordo'
                                onClick={() => setIsModalOpen(true)}>
                                Deletar Perfil
                            </button>
                            <DeleteUserModal
                                id={userId}
                                isOpen={isModalOpen}
                                onClose={() => setIsModalOpen(false)}
                            />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default UserProfile;