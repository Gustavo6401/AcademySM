import IMaximumCharacterStrategy from "./maximumCharacterStrategy";

export default class UpperStrategy implements IMaximumCharacterStrategy {
    private upperChars: string = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

    characterValid(character: string): boolean {
        return this.upperChars.includes(character)
    }

}