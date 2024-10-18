import NavbarWhite from '../../components/navbarWhite/Index.jsx'
import fotoGustavo from '../../assets/image/foto_gustavo.jpg'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-icons/font/bootstrap-icons.css'
import './Index.css'
import UserDetailsViewModel from '../../../domain/models/viewModels/userDetailsViewModel.js'
import { useState, useEffect } from 'react'
import UserDetailsViewServices from '../../services/userDetailsViewServices.js'
import FormationsName from '../../../domain/models/viewModels/formationsName.js'

function DetalhesUsuario() {
    const pathParts: string[] = window.location.pathname.split('/') // Devide URL in equal parts
    /**
     * https:
     * academysm.com
     * DetalhesUsuario
     * userId
     */
    const userId = pathParts[pathParts.length - 1] // Catches the last item of array.

    const [userDetails, setUserDetails] = useState<UserDetailsViewModel | undefined>(undefined)

    const services: UserDetailsViewServices = new UserDetailsViewServices()    

    useEffect(() => {
        const fetchUserDetails = async () => {
            const details: UserDetailsViewModel = await services.details(userId)

            const formationsArray: Array<FormationsName> = details.getFormations().map((formation) =>
                new FormationsName(formation.getId(), formation.getNome())
            )

            setUserDetails(new UserDetailsViewModel(details.getId(),
                details.getFullName(),
                details.getFormation(),
                details.getProfilePicFileName(),
                formationsArray))
        }

        fetchUserDetails()
    }, []) // Void arrrays are responsible for executing the effect once whenever the component is initialized.

    return (
        <div>
            <NavbarWhite />
            <main className='detalhesUsuario'>
                <div className='levelAndCourses'>
                    <div className='level'>
                        <h2 className='levelTitle'>Nível</h2>
                        <div className='levelHexagon hexagon'>
                            <div className='internalLevelHexagon hexagon'>
                                <label className='audiowide'>0</label>
                            </div>
                        </div>
                    </div>
                    <h3>Cursos</h3>
                    <hr />
                    <div className='courses'>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-music-note-beamed"></i>
                            </div>
                            <label className='courseLabel'>Aula de Canto</label>
                        </div>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-translate"></i>
                            </div>
                            <label className='courseLabel'>Aula de Inglês</label>
                        </div>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-cpu-fill"></i>
                            </div>
                            <label className='courseLabel'>Aula de Programação</label>
                        </div>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-hourglass-split"></i>
                            </div>
                            <label className='courseLabel'>Aula de História</label>
                        </div>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-vector-pen"></i>
                            </div>
                            <label className='courseLabel'>Aula de Desenho</label>
                        </div>
                    </div>
                </div>
                <div className='middleComponentUserDetails'>
                    <div >
                        <img className='componentRoundImage' src={fotoGustavo} />
                    </div>
                    <div className='componentIsolator-1'>
                        <h1>{userDetails ? userDetails?.getFullName() : 'Carregando...'}</h1>
                    </div>
                    <div className='componentIsolator-1'>
                        <h2>{userDetails ? userDetails?.getFormation() : 'Carregando...'}</h2>
                    </div>
                    <div className='componentIsolator-1'>
                        <label>Formações</label>
                        <hr />
                    </div>
                    <div className='formations'>
                        {userDetails ? userDetails?.getFormations().map(item => 
                            <div className='formationComponent'>
                                <div className='smallCircle vermelho'>
                                    <i className="bi bi-cpu-fill"></i>
                                </div>
                                <label>{item.getNome()}</label>
                            </div>
                        ) : 'Carregando...'}
                    </div>
                </div>
                <div className='batePaposEmGrupo'>
                    <label className='chatTitle'>Chat em Grupo</label>
                    <div className='courses'>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-music-note-beamed"></i>
                            </div>
                            <label className='courseLabel'>Aula de Canto</label>
                        </div>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-translate"></i>
                            </div>
                            <label className='courseLabel'>Aula de Inglês</label>
                        </div>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-cpu-fill"></i>
                            </div>
                            <label className='courseLabel'>Aula de Programação</label>
                        </div>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-hourglass-split"></i>
                            </div>
                            <label className='courseLabel'>Aula de História</label>
                        </div>
                        <div className='courseComponent'>
                            <div className='smallCircle branco'>
                                <i className="bi bi-vector-pen"></i>
                            </div>
                            <label className='courseLabel'>Aula de Desenho</label>
                        </div>
                    </div>
                </div>
            </main>
        </div>
    );
}

export default DetalhesUsuario;