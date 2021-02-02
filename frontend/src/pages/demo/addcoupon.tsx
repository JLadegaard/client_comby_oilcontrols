import { Box, Container, useColorModeValue, useToast } from "@chakra-ui/react";
import AddCouponComp from "components/CouponManagement/AddCoupon/AddCouponComp";
import { AddCouponForm } from "components/CouponManagement/AddCoupon/AddCouponForm";
import { Locale } from "i18n/Locale";
import { GetStaticProps, NextPage } from "next";
import { I18nProps } from "next-rosetta";
import { useEffect, useState } from "react";

const DemoPage: NextPage = () => {
  const [addCouponForm, setCouponForm] = useState<number[]>(null);
  const toast = useToast();
  const bg = useColorModeValue("gray.100", "gray.700");

  useEffect(() => {
    if (addCouponForm) {
      toast({
        title: "Coupon added",
        description: JSON.stringify(addCouponForm),
        status: "success",
        duration: 9000,
        isClosable: true
      });
    }
  }, [addCouponForm]);

  return (
    <Container maxW="xl" centerContent>
      <Box padding="4" bg={bg} maxW="6xl" maxH="4xl" resize="both" overflow="auto">
        <AddCouponComp coupons={[]} submitCallback={x => setCouponForm(x)}></AddCouponComp>
      </Box>
    </Container>
  );
};

export const getStaticProps: GetStaticProps<I18nProps<Locale>> = async context => {
  const locale = context.locale || context.defaultLocale;

  const { table = {} } = await import(`../../i18n/${locale}`);
  return { props: { table } };
};

export default DemoPage;
