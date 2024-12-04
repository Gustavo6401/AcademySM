import Navbar from '../../components/navbar/index'
import GroupDescription from '../../components/groupDescription/Index.tsx';
import PostComponent from '../../components/post/Index.tsx';
import GroupsNavbar from '../../components/groupsNavbar/Index';
import grupoAbaArtigos from '../../assets/image/Grupo - Aba Artigos.png'
import { useEffect, useState } from 'react';
import GroupHomeApplicationServices from '../../services/groupHomeApplicationServices';
import GroupHomeViewModel from '../../../domain/models/apis/groups/return/groupHomeViewModel.ts';
import Post from '../../../domain/models/apis/groups/post.ts';
import navigateTo from '../../../infra/navigation/navigation.ts';
import './Index.css'

export default function GruposHomePage() {
    const [groupDetails, setGroupDetails] = useState<GroupHomeViewModel | undefined>(undefined)
    const [id, setId] = useState<string>('')
    const [name, setName] = useState<string>('')
    const [level, setLevel] = useState<string>('')
    const [description, setDescription] = useState<string>('')
    const [posts, setPosts] = useState<Array<Post> | undefined>(undefined)

    const pathParts: Array<string> = window.location.pathname.split('/')

    const groupId: string = pathParts[pathParts.length - 1]

    const groupHomeAppServices: GroupHomeApplicationServices = new GroupHomeApplicationServices()

    var photos = new Array()
    photos.push(grupoAbaArtigos)

    useEffect(() => {
        const fetchGroupDetails = async () => {
            try {
                const courses: GroupHomeViewModel = await groupHomeAppServices.get(groupId)

                setId(courses.getId())
                setName(courses.getName())
                setLevel(courses.getLevel())
                setDescription(courses.getDescription())
                setPosts(courses.getPosts())
            } catch (error: any) {
                if (error.message.includes("Erro 403")) {
                    alert("Você Não Está Autorizado para Acessar esse Grupo, Redirecionando para a Tela de Login.")
                    navigateTo('/Login')
                } else {
                    console.log('Erro Inesperado: ', error)
                }
            }
        }

        fetchGroupDetails()
    }, [])

    return (
        <div>
            <Navbar />
            <div className='groupsHomePage'>
                <main className='groups-index'>
                    <GroupDescription icon='bi bi-music-note-beamed' courseTitle={name} percentageConcluded={55} />
                    {posts ? (
                        posts.map((post) =>
                            <PostComponent title={post.getTitle()} text={post.getContent()} images={photos} />
                        )
                    ) : (
                        <p>Nenhum post disponível.</p>
                    )}
                    <div className='group-component-description'>
                        <h1 className='group-description-title'>Descrição</h1>
                        <hr />
                        <p className='group-description-text'>{description}</p>
                    </div>
                </main>
                <div className='barra-navegacao-grupos'>
                    <GroupsNavbar />                    
                </div>
            </div>
        </div>
    )
}