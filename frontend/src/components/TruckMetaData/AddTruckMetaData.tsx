import {
  Button,
  Container,
  FormControl,
  FormErrorMessage,
  FormLabel,
  Input,
  InputGroup,
  InputRightAddon,
  NumberInput,
  NumberInputField,
  Textarea,
  VStack
} from "@chakra-ui/react";
import { Locale } from "i18n/Locale";
import { useI18n } from "next-rosetta";
import React, { FC, FormEvent, useCallback, useState } from "react";
import { MdCheck } from "react-icons/md";
import { TruckInfoDto, TruckInfoIdDto } from "services/backend/nswagts";
import { logger } from "utils/logger";

type Props = {
  submitCallback: (truckMetaDataForm: TruckInfoDto) => void;
  truckMetaData?: TruckInfoIdDto;
};

const AddTruckMetaData: FC<Props> = ({ submitCallback, truckMetaData }) => {
  const [localTruckMetaDataForm, setLocalTruckMetaDataForm] = useState<TruckInfoDto>(
    truckMetaData ??
      new TruckInfoDto({
        refillNumber: null,
        truckIdentifier: null,
        description: null,
        name: null,
        tankCapacity: null
      })
  );

  const { t } = useI18n<Locale>();

  const [formSubmitAttempts, setFormSubmitAttempts] = useState(0);

  const updateLocalForm = useCallback((value: unknown, key: keyof TruckInfoDto) => {
    setLocalTruckMetaDataForm(form => {
      (form[key] as unknown) = value;
      return form;
    });
  }, []);

  const handleSubmit = useCallback(
    (event: FormEvent<HTMLFormElement>) => {
      logger.debug("Submitting form AddTruckMetaDataForm");

      submitCallback(localTruckMetaDataForm);
      setFormSubmitAttempts(0);
      event.preventDefault();
    },
    [localTruckMetaDataForm]
  );

  return (
    <Container>
      <form onSubmit={handleSubmit}>
        <VStack align="center" justify="center">
          <FormControl>
            <FormLabel>{t("truckMetaData.startNumber")}:</FormLabel>
            <Input value={localTruckMetaDataForm.refillNumber}></Input>
          </FormControl>

          <FormControl
            isRequired
            isInvalid={formSubmitAttempts > 0 && !localTruckMetaDataForm.truckIdentifier}>
            <FormLabel> {t("truckMetaData.carNumber")}:</FormLabel>
            <NumberInput
              min={0}
              max={999}
              onChange={value => {
                updateLocalForm(value, "truckIdentifier");
              }}>
              <NumberInputField />
            </NumberInput>
            <FormErrorMessage>{t("truckMetaData.formError.carNumber")}</FormErrorMessage>
          </FormControl>

          <FormControl
            isRequired
            isInvalid={formSubmitAttempts > 0 && !localTruckMetaDataForm.name}>
            <FormLabel>{t("truckMetaData.carName")}:</FormLabel>
            <Input
              onChange={e => {
                updateLocalForm(e.target.value, "name");
              }}></Input>
            <FormErrorMessage>{t("truckMetaData.formError.carName")}</FormErrorMessage>
          </FormControl>

          <FormControl
            isRequired
            isInvalid={formSubmitAttempts > 0 && !localTruckMetaDataForm.description}>
            <FormLabel>{t("truckMetaData.description")}:</FormLabel>
            <Textarea
              onChange={e => {
                updateLocalForm(e.target.value, "description");
              }}></Textarea>
            <FormErrorMessage>{t("truckMetaData.formError.description")}</FormErrorMessage>
          </FormControl>

          <FormControl
            isRequired
            isInvalid={formSubmitAttempts > 0 && !localTruckMetaDataForm.tankCapacity}>
            <FormLabel>{t("truckMetaData.tankSize")}:</FormLabel>
            <InputGroup>
              <NumberInput
                min={0}
                onChange={value => {
                  updateLocalForm(value, "tankCapacity");
                }}>
                <NumberInputField />
              </NumberInput>

              <InputRightAddon>liters</InputRightAddon>
            </InputGroup>
            <FormErrorMessage>{t("truckMetaData.formError.tankSize")}</FormErrorMessage>
          </FormControl>

          <Button
            colorScheme="green"
            type="submit"
            rightIcon={<MdCheck />}
            onClick={() => setFormSubmitAttempts(x => x + 1)}>
            Submit
          </Button>
        </VStack>
      </form>
    </Container>
  );
};

export default AddTruckMetaData;