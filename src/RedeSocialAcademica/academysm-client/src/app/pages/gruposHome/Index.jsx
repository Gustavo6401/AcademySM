import React, { useState } from 'react';
import Navbar from '../../components/navbar/index'
import foto from '../../assets/image/foto_gustavo.webp'
import grupoAbaArtigos from '../../assets/image/Grupo - Aba Artigos.png'
import './Index.css'
import GroupsNavbar from '../../components/groupsNavbar/Index';
import Post from '../../components/post/Index';
import GroupDescription from '../../components/groupDescription/Index';
import Courses from '../../../domain/models/apis/groups/courses'
import GroupHomeApplicationServices from '../../services/groupHomeApplicationServices'
import { useEffect } from 'react';

export default function GruposHomePage() {
    const [groupDetails, setGroupDetails] = useState(new Object())

    /** @type {string[]} */
    const pathParts = window.location.pathname.split('/')

    /** @type {string} */
    const groupId = pathParts[pathParts.length - 1]

    const groupHomeAppServices = new GroupHomeApplicationServices()

    /** @type {string[]} */
    var photos = new Array()
    photos.push(grupoAbaArtigos)

    useEffect(() => {
        const fetchCourses = async () => {
            /** @type {Courses} */
            const courses = await groupHomeAppServices.get(groupId)

            setGroupDetails(new Courses(courses.getId(), courses.getName(), courses.getLevel(), courses.getTutor()
                , courses.getDescription(), courses.getIsPublic()))
        }
    })

    return (
        <div>
            <Navbar />
            <div className='groupsHomePage'>
                <main className='groups-index'>
                    <GroupDescription icon='bi bi-music-note-beamed' courseTitle={groupDetails.getName()} percentageConcluded={55} />
                    <Post title='Título do Artigo' text='Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.' images={photos} />
                </main>
                <div>
                    <section className='group-description-display-none'>
                        <div className='groupCategoryIcon'>
                            <i className="bi bi-music-note-beamed"></i>
                        </div>
                        <div className='description'>
                            <h1>Curso Básico de Canto Lírico</h1>
                            <label className='conclusionPercentage'>55% Concluído</label>
                        </div>
                    </section>
                    <GroupsNavbar />
                    <div className='group-component-description'>
                        <h1 className='group-description-title'>Descrição</h1>
                        <hr />
                        <p className='group-description-text'>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                </div>
            </div>
        </div>
    );
}