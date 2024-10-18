import Navbar from '../../components/navbar/index'
import GroupDescription from '../../components/groupDescription/Index.tsx';
import Post from '../../components/post/Index.tsx';
import GroupsNavbar from '../../components/groupsNavbar/Index';
import grupoAbaArtigos from '../../assets/image/Grupo - Aba Artigos.png'
import { useEffect, useState } from 'react';
import Courses from '../../../domain/models/apis/groups/courses';
import GroupHomeApplicationServices from '../../services/groupHomeApplicationServices';

export default function GruposHomePage() {
    const [groupDetails, setGroupDetails] = useState<Courses | undefined>(undefined)

    const pathParts: Array<string> = window.location.pathname.split('/')

    const groupId: string = pathParts[pathParts.length - 1]

    const groupHomeAppServices: GroupHomeApplicationServices = new GroupHomeApplicationServices()

    var photos = new Array()
    photos.push(grupoAbaArtigos)

    useEffect(() => {
        const fetchGroupDetails = async () => {
            const courses: Courses = await groupHomeAppServices.get(groupId)

            setGroupDetails(new Courses(courses.getId(), courses.getName(), courses.getLevel(), courses.getTutor()
                , courses.getDescription(), courses.getIsPublic()))
        }

        fetchGroupDetails()
    }, [])

    return (
        <div>
            <Navbar />
            <div className='groupsHomePage'>
                <main className='groups-index'>
                    <GroupDescription icon='bi bi-music-note-beamed' courseTitle={groupDetails?.getName()} percentageConcluded={55} />
                    <Post title='Título do Artigo' text='Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.' images={photos} />
                </main>
                <div>
                    <section className='group-description-display-none'>
                        <div className='groupCategoryIcon'>
                            <i className="bi bi-music-note-beamed"></i>
                        </div>
                        <div className='description'>
                            <h1>{groupDetails?.getName()}</h1>
                            <label className='conclusionPercentage'>55% Conclu�do</label>
                        </div>
                    </section>
                    <GroupsNavbar />
                    <div className='group-component-description'>
                        <h1 className='group-description-title'>Descri��o</h1>
                        <hr />
                        <p className='group-description-text'>{groupDetails?.getDescription()}</p>
                    </div>
                </div>
            </div>
        </div>
    )
}