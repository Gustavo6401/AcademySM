import GroupsApplicationUser from "../../domain/models/apis/groups/applicationUser";
import ApplicationUser from "../../domain/models/apis/user/applicationUser";
import EducationalBackground from "../../domain/models/apis/user/educationalBackground";
import Links from "../../domain/models/apis/user/links";
import ProfilePic from "../../domain/models/apis/user/profilePic";
import UserCreateResponse from "../../domain/models/apis/user/userCreateResponse";
import GroupsApplicationUserAPI from "../../infra/api/groups/applicationUserAPI";
import ApplicationUserAPI from "../../infra/api/user/applicationUserAPI";
import EducationalBackgroundAPI from "../../infra/api/user/educationalBackgroundAPI";
import LinkAPI from "../../infra/api/user/linkAPI";
import ProfilePicAPI from "../../infra/api/user/profilePicAPI";
import UploadAPI from "../../infra/api/utils/uploadAPI";
import ImageConvertion from "../../infra/fileConvertion/imageConvertion";

export default class CadastroUsuarioViewServices {
    private applicationUserAPI: ApplicationUserAPI = new ApplicationUserAPI()
    private groupsApplicationUserAPI: GroupsApplicationUserAPI = new GroupsApplicationUserAPI()
    private educationalBackgroundAPI: EducationalBackgroundAPI = new EducationalBackgroundAPI()
    private profilePicAPI: ProfilePicAPI = new ProfilePicAPI()
    private uploadAPI: UploadAPI = new UploadAPI()
    private linkAPI: LinkAPI = new LinkAPI()

    async create(user: ApplicationUser, groupsAppUser: GroupsApplicationUser,
        educationalBackgrounds: Array<EducationalBackground>, profilePicture: ProfilePic, file: File | undefined,
            links: Array<Links>) : Promise<string> {
        const resposta: UserCreateResponse = await this.applicationUserAPI.createAsync(user)

        if (file) {
            const webpImage: Blob | undefined = await ImageConvertion(file)
            const formData = new FormData()

            if (webpImage) {
                formData.append('file', webpImage, file.name)
            } else {
                console.error("Erro ao Converter a Imagem")
                throw new Error('Erro ao Converter a Imagem')
            }

            const fileName = await this.uploadAPI.upload(formData)

            profilePicture.setUserId(resposta.getUserId())
            profilePicture.setFileNameAndPath(fileName)

            await this.profilePicAPI.createAsync(profilePicture)
        }

        groupsAppUser.setId(resposta.getUserId())

        await this.groupsApplicationUserAPI.createAsync(groupsAppUser)

        if (educationalBackgrounds.length > 0) {
            educationalBackgrounds.forEach(async (educationalBackground) => {
                educationalBackground.setUserId(resposta.getUserId())

                await this.educationalBackgroundAPI.createAsync(educationalBackground)
            })
        }

        if (links.length > 0) {
            links.forEach(async (link: Links) => {
                link.setUserId(resposta.getUserId())

                await this.linkAPI.createAsync(link)
            })
        }

        return resposta.getMessage()
    }
}