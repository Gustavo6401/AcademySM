import GroupsApplicationUser from "../../domain/models/apis/groups/applicationUser";
import ApplicationUser from "../../domain/models/apis/user/applicationUser";
import EducationalBackground from "../../domain/models/apis/user/educationalBackground";
import ProfilePic from "../../domain/models/apis/user/profilePic";
import UserCreateResponse from "../../domain/models/apis/user/userCreateResponse";
import GroupsApplicationUserAPI from "../../infra/api/groups/applicationUserAPI";
import ApplicationUserAPI from "../../infra/api/user/applicationUserAPI";
import EducationalBackgroundAPI from "../../infra/api/user/educationalBackgroundAPI";
import ProfilePicAPI from "../../infra/api/user/profilePicAPI";
import UploadAPI from "../../infra/api/utils/uploadAPI";
import ImageConvertion from "../../infra/fileConvertion/imageConvertion";

export default class CadastroUsuarioViewServices {
    private applicationUserAPI: ApplicationUserAPI = new ApplicationUserAPI()
    private groupsApplicationUserAPI: GroupsApplicationUserAPI = new GroupsApplicationUserAPI()
    private educationalBackgroundAPI: EducationalBackgroundAPI = new EducationalBackgroundAPI()
    private profilePicAPI: ProfilePicAPI = new ProfilePicAPI()
    private uploadAPI: UploadAPI = new UploadAPI()

    async create(user: ApplicationUser, groupsAppUser: GroupsApplicationUser,
        educationalBackgrounds: Array<EducationalBackground>, profilePicture: ProfilePic, file: File)
            : Promise<string> {
        const resposta: UserCreateResponse = await this.applicationUserAPI.createAsync(user)

        const webpImage: Blob | undefined = await ImageConvertion(file)
        const formData = new FormData()

        if (webpImage) {
            formData.append('file', webpImage, file.name)
        } else {
            console.error("Erro ao Converter a Imagem")
            throw new Error('Erro ao Converter a Imagem')
        }       

        const fileName = await this.uploadAPI.upload(formData)

        groupsAppUser.setId(resposta.getUserId())

        await this.groupsApplicationUserAPI.createAsync(groupsAppUser)

        educationalBackgrounds.forEach(async (educationalBackground) => {
            educationalBackground.setUserId(resposta.getUserId())

            await this.educationalBackgroundAPI.createAsync(educationalBackground)
        })        

        profilePicture.setUserId(resposta.getUserId())
        profilePicture.setFileNameAndPath(fileName)

        await this.profilePicAPI.createAsync(profilePicture)

        return resposta.getMessage()
    }
}