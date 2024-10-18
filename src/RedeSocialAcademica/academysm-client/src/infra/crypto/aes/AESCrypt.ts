import CryptoJS from "crypto-js";
export default class AESCrypt {
    crypt(info: string, key: string): string {
        const cryptedInfo: string = CryptoJS.AES.encrypt(info, key)
                                        .toString()

        return cryptedInfo
    }

    decrypt(info: string, key: string) {
        const decryptedInfo: string = CryptoJS.AES.decrypt(info, key)
            .toString()

        return decryptedInfo
    }
}